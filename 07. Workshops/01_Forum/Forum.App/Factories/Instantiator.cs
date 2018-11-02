namespace Forum.App.Factories
{
    using System.Linq.Expressions;
    using System.Reflection;

    public static class Instantiator
    {
        public static T CreateInstance<T>(ConstructorInfo ctor, object[] args)
        {
            var type = ctor.DeclaringType;
            var paramsInfo = ctor.GetParameters();

            //create a single param of type object[]
            var param = Expression.Parameter(typeof(object[]), "args");

            var argsExp = new Expression[paramsInfo.Length];

            //pick each arg from the params array and create a typed expression of them
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                var index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                var paramAccessorExp = Expression.ArrayIndex(param, index);

                var paramCastExp = Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the ctor with the args we just created
            var newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New Expression as body and our param object[] as arg
            var lambda = Expression.Lambda(typeof(T), newExp, param);

            //compile it
            var compiled = lambda.Compile();
            //Invoke it
            return (T)compiled.DynamicInvoke(args);
        }
    }
}