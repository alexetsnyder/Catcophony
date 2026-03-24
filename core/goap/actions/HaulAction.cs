using Catcophony.core.goap.goals;
using Catcophony.core.naming;
using Catcophony.data.enums;

namespace Catcophony.core.goap.actions
{
    public partial class HaulAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 1; }

        private readonly FastName _name = new("HaulAction");

        public HaulAction()
        {
            WorkGoal workGoal = new();
            _effects.Add(workGoal);
      
            HasWorkGoal hasWorkGoal = new(WorkType.HAULING, this);
            FalseAdjToGoal adjToGoal = new(this);
            HasItemGoal hasItemGoal = new(this);
            _preconditions.Add(hasWorkGoal);
            _preconditions.Add(adjToGoal);
            _preconditions.Add(hasItemGoal);
        }
    }
}