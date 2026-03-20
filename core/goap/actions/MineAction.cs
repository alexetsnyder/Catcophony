using Quasar.core.goap.goals;
using Quasar.core.naming;
using Quasar.data.enums;

namespace Quasar.core.goap.actions
{
    public partial class MineAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 1; }

        private readonly FastName _name = new("MineAction");

        public MineAction()
        {
            _blackboard = new();

            WorkGoal workGoal = new();
            _effects.Add(workGoal);

            HasWorkGoal hasWorkGoal = new(WorkType.MINING, this);
            HasProfGoal hasProfGoal = new(this);
            AdjToGoal adjToGoal = new(this);
            _preconditions.Add(hasWorkGoal);
            _preconditions.Add(hasProfGoal);
            _preconditions.Add(adjToGoal);
        }
    }
}