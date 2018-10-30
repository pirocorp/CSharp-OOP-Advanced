namespace ObjectCommunicationAndEventsLab.Commands
{
    using Interfaces;

    public class GroupTargetCommand : ICommand
    {
        private readonly IAttackGroup attackGroup;
        private readonly ITarget target;

        public GroupTargetCommand(IAttackGroup attackGroup, ITarget target)
        {
            this.attackGroup = attackGroup;
            this.target = target;
        }

        public void Execute()
        {
            this.attackGroup.GroupTarget(this.target);
        }
    }
}