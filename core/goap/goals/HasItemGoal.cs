using Quasar.core.blackboard;
using Quasar.core.common;

namespace Quasar.core.goap.goals
{
    public partial class HasItemGoal : GoalBase
    {
        public HasItemGoal()
        {
            _key = new("HasItem");
            _value = true;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetItem(Constants.Names.Item, out var item))
            {
                if (item != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}