namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Parser.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Lifecycle;
    using Lifecycle.Controller;
    using Lifecycle.Request;
    using Providers.TypeProvider;

    public class ControllerParserStrategy : IAttributeParserStrategy<RequestMethod, IDictionary<string, ControllerActionPair>>
    {
        private readonly ITypeProvider typeProvider;

        public ControllerParserStrategy(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Parse(IDictionary<RequestMethod, IDictionary<string, ControllerActionPair>> result)
        {
            foreach (var controller in this.typeProvider.GetClassesByAttribute(typeof(ControllerAttribute)))
            {
                foreach (var currentMethod in this.typeProvider.GetMethodsByAttribute(controller, typeof(RequestMappingAttribute)))
                {
                    var requestMapping = currentMethod.GetCustomAttribute<RequestMappingAttribute>();
                    var requestMethod = requestMapping.Method;
                    var mapping = requestMapping.Value;
                    var mappingTokens = mapping.Split('/').ToList();

                    var argumentsMapping = new Dictionary<int, Type>();

                    mapping = this.ConvertPlaceholdersToRegex(mappingTokens, currentMethod, argumentsMapping, mapping);

                    var controllerInstance = Activator.CreateInstance(controller);

                    var pair = new ControllerActionPair(controllerInstance, currentMethod, argumentsMapping);

                    if (!result.ContainsKey(requestMethod))
                    {
                        result.Add(requestMethod, new Dictionary<string, ControllerActionPair>());
                    }

                    result[requestMethod].Add(mapping, pair);
                }
            }
        }

        private string ConvertPlaceholdersToRegex(List<string> mappingTokens, MethodInfo currentMethod, Dictionary<int, Type> argumentsMapping, string mapping)
        {
            for (var i = 0; i < mappingTokens.Count; i++)
            {
                if (mappingTokens[i].StartsWith("{") && mappingTokens[i].EndsWith("}"))
                {
                    foreach (var parameterInfo in currentMethod.GetParameters())
                    {
                        if (parameterInfo.GetCustomAttributes().All(x => x.GetType() != typeof(UriParameterAttribute)))
                        {
                            continue;
                        }

                        var uriParameter = parameterInfo.GetCustomAttribute<UriParameterAttribute>();

                        if (mappingTokens[i].Equals("{" + uriParameter.Value + "}"))
                        {
                            argumentsMapping.Add(i, parameterInfo.ParameterType);

                            mapping = mapping.Replace(mappingTokens[i], parameterInfo.ParameterType == typeof(string) ? "\\w+" : "\\d+");
                            break;
                        }
                    }
                }
            }

            return mapping;
        }
    }
}