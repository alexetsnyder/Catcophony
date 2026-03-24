using Catcophony.core.blackboard;
using Catcophony.core.naming;

namespace Catcophony.core.goap.goals
{
    public partial class WorkGoal : GoalBase
    {
        public WorkGoal() 
        {
            _key = new("HasWorked");
            _value = true;
        }

        public override bool Satisify(WorldState worldState, Blackboard<FastName> blackboard)
        {
            throw new System.NotImplementedException();
        }
    }
}