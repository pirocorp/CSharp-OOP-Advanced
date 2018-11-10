namespace LambdaCore.Core.FactoryHandlers
{
    using System;
    using System.Reflection;
    using Interfaces.Core.Factories;
    using Interfaces.Core.FactoryHandlers;
    using Interfaces.Models;

    public class FragmentsFactoryHandler : IFragmentsFactoryHandler
    {
        private readonly IFragmentsFactory fragmentsFactory;

        public FragmentsFactoryHandler(IFragmentsFactory fragmentsFactory)
        {
            this.fragmentsFactory = fragmentsFactory;
        }

        public bool TryCreateFragment(string[] args, out IFragment newFragment)
        {
            newFragment = null;

            try
            {
                newFragment = this.fragmentsFactory.CreateFragment(args);
            }
            catch (TargetInvocationException tie)
            {
                return false;
            }
            catch (InvalidOperationException Ioe)
            {
                return false;
            }

            return true;
        }
    }
}