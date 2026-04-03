using Catcophony.core.blackboard;
using Catcophony.core.naming;
using System;

namespace Catcophony.core.goap.goals
{
    public partial class WaterGoal : GoalBase
    {
        public WaterGoal()
        {
            _key = new("Water");
            _value = true;
        }

        public override bool Satisify(WorldState worldState, Blackboard<FastName> blackboard)
        {
            throw new NotImplementedException();
        }
    }
}