namespace LambdaCore.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Constants;
    using Interfaces.Controllers;
    using Interfaces.Core.FactoryHandlers;
    using Interfaces.Models;

    public class LambdaCoreController : ILambdaCoreController
    {
        private char startLetter = 'A';
        private ICore selectedCore;
        private readonly IDictionary<char, ICore> cores;

        private readonly ICoreFactoryHandler coreFactoryHandler;
        private readonly IFragmentsFactoryHandler fragmentsFactoryHandler;

        public LambdaCoreController(ICoreFactoryHandler coreFactoryHandler, IFragmentsFactoryHandler fragmentsFactoryHandler)
        {
            this.cores = new Dictionary<char, ICore>();
            this.coreFactoryHandler = coreFactoryHandler;
            this.fragmentsFactoryHandler = fragmentsFactoryHandler;
            this.selectedCore = null;
        }

        public string CreateCore(string[] args)
        {
            //CreateCore:@type@durability
            var coreName = this.startLetter;

            var result = this.coreFactoryHandler.CreateCore(coreName, args, out var newCore);

            if (newCore != null)
            {
                this.cores.Add(coreName, newCore);
                this.startLetter++;
            }

            return result;
        }

        public string RemoveCore(string[] args)
        {
            //RemoveCore:@name
            var coreName = args[0][0];

            if (!this.cores.ContainsKey(coreName))
            {
                return string.Format(Messages.CoreForRemoveNotFound, coreName);
            }

            this.cores.Remove(coreName);

            if (this.selectedCore.Name == new string(coreName, 1))
            {
                this.selectedCore = null;
            }

            return string.Format(Messages.CoreRemovedSuccessfully, coreName);
        }

        public string SelectCore(string[] args)
        {
            //SelectCore:@name
            var coreName = args[0][0];

            if (!this.cores.ContainsKey(coreName))
            {
                return string.Format(Messages.CoreToSelectNotFound, coreName);
            }

            this.selectedCore = this.cores[coreName];
            return string.Format(Messages.CoreSelectedSuccessfully, coreName);
        }

        public string AttachFragment(string[] args)
        {
            //AttachFragment:@type@name@pressureAffection
            var fragmentIsCreated = this.fragmentsFactoryHandler.TryCreateFragment(args, out var newFragment);

            var fragmentName = args[1];

            if (!fragmentIsCreated)
            {
                return string.Format(Messages.FragmentAttachingFailed, fragmentName);
            }

            if (this.selectedCore == null)
            {
                return string.Format(Messages.FragmentAttachingFailed, fragmentName);
            }

            this.selectedCore.AddFragment(newFragment);
            return string.Format(Messages.FragmentAttachedSuccessfully, fragmentName, this.selectedCore.Name);
        }

        public string DetachFragment(string[] args)
        {
            if (this.selectedCore == null)
            {
                return string.Format(Messages.FragmentDetachingFailed);
            }

            if (this.selectedCore.Fragments.Count == 0)
            {
                return string.Format(Messages.FragmentDetachingFailed);
            }

            var removedFragment = this.selectedCore.RemoveFragment();
            return string.Format(Messages.FragmentDetachedSuccessfully, removedFragment.Name, this.selectedCore.Name);
        }

        public string Status(string[] args)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Lambda Core Power Plant Status:");
            sb.AppendLine($"Total Durability: {this.cores.Sum(c => c.Value.Durability)}");
            sb.AppendLine($"Total Cores: {this.cores.Count}");
            sb.AppendLine($"Total Fragments: {this.cores.Sum(c => c.Value.Fragments.Count)}");

            foreach (var core in this.cores)
            {
                sb.AppendLine($"Core {core.Value.Name}:");
                sb.AppendLine($"####Durability: {core.Value.Durability}");
                sb.AppendLine($"####Status:{core.Value.Status}");
            }

            return sb.ToString().Trim();
        }
    }
}