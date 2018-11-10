namespace LambdaCore.Core.FactoryHandlers
{
    using System;
    using System.Reflection;
    using Constants;
    using Interfaces.Core.Factories;
    using Interfaces.Core.FactoryHandlers;
    using Interfaces.Models;

    public class CoreFactoryHandler : ICoreFactoryHandler
    {
        private readonly ICoreFactory coreFactory;

        public CoreFactoryHandler(ICoreFactory coreFactory)
        {
            this.coreFactory = coreFactory;
        }

        public string CreateCore(char coreName, string[] args, out ICore newCore)
        {
            newCore = null;

            try
            {
                newCore = this.coreFactory.CreateCore(coreName, args);
            }
            catch (TargetInvocationException tie)
            {
                return Messages.CreationCoreFailed;
            }
            catch (InvalidOperationException Ioe)
            {
                return Messages.CreationCoreFailed;
            }

            return string.Format(Messages.CreationCoreSuccessfully, coreName);
        }
    }
}