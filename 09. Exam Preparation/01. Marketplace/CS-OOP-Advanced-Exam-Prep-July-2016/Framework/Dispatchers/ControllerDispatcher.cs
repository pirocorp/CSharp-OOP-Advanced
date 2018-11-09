namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Dispatchers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Container;
    using Lifecycle.Controller;
    using Lifecycle.Request;
    using Parser;
    using Parser.Strategies;
    using Providers.TypeProvider;

    public class ControllerDispatcher : IDispatcher
    {
        private readonly IDictionary<RequestMethod, IDictionary<string, ControllerActionPair>> controllers;
        private readonly IParser parser;
        private readonly IDependencyContainer container;
        private readonly ITypeProvider typeProvider;

        public ControllerDispatcher(IParser parser, IDependencyContainer container, ITypeProvider typeProvider)
        {
            this.parser = parser;
            this.container = container;
            this.typeProvider = typeProvider;
            this.controllers = new Dictionary<RequestMethod, IDictionary<string, ControllerActionPair>>();
            this.FillControllers();
            this.BuildDependencyGraph();
        }

        public string Dispatch(RequestMethod requestMethod, string uri)
        {
            var uriTokens = uri.Split('/');

            var innerDictionary = this.controllers[requestMethod];

            foreach (var actionPair in innerDictionary)
            {
                var regex = actionPair.Key;
                var controllerAction = actionPair.Value;

                var arguments = new object[controllerAction.ArgumentsMapping.Count];
                var argumentsIndex = 0;

                if (Regex.IsMatch(uri, regex))
                {
                    foreach (var argumentPair in controllerAction.ArgumentsMapping)
                    {
                        var argument = uriTokens[argumentPair.Key];
                        var argumentToPass = Convert.ChangeType(argument, argumentPair.Value);
                        arguments[argumentsIndex++] = argumentToPass;
                    }

                    var controller = controllerAction.Controller;
                    var method = controllerAction.Action;

                    return (string)method.Invoke(controller, arguments);
                }
            }

            return null;
        }

        private void FillControllers()
        {
            this.parser.Parse(new ControllerParserStrategy(this.typeProvider), this.controllers);
        }

        private void BuildDependencyGraph()
        {
            foreach (var controller in this.controllers.Values.SelectMany(c => c.Values).Select(c => c.Controller))
            {
                this.container.ResolveDependencies(controller);
            }
        }
    }
}