namespace LambdaCore.Constants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Messages
    {
        public const string CreationCoreFailed = "Failed to create Core!";

        public const string CreationCoreSuccessfully = "Successfully created Core {0}!";

        public const string CoreForRemoveNotFound = "Failed to remove Core {0}!";

        public const string CoreRemovedSuccessfully = "Successfully removed Core {0}!";

        public const string CoreToSelectNotFound = "Failed to select Core {0}!";

        public const string CoreSelectedSuccessfully = "Currently selected Core {0}!";

        public const string FragmentAttachedSuccessfully = "Successfully attached Fragment {0} to Core {1}!";

        public const string FragmentAttachingFailed = "Failed to attach Fragment {0}!";

        public const string FragmentDetachedSuccessfully = "Successfully detached Fragment {0} from Core {1}!";

        public const string FragmentDetachingFailed = "Failed to detach Fragment!";
    }
}