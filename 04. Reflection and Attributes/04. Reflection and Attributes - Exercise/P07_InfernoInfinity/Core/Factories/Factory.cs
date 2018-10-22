namespace P07_InfernoInfinity.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public abstract class Factory<T> : IFactory<T>
    {
        public virtual T Create(string typeOfProduct, object[] inputParams)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == typeOfProduct);

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Weapon type: {typeOfProduct}");
            }

            if (!(Activator.CreateInstance(type, inputParams) is T currentInstance))
            {
                throw new NotSupportedException($"Incorrect Weapon type: {typeOfProduct}");
            }

            return currentInstance;
        }

        public abstract T Create(params string[] productType);
    }
}