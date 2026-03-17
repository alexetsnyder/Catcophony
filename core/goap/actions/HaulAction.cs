using Quasar.core.blackboard;
using Quasar.core.goap.goals;
using Quasar.core.naming;
using Quasar.data.enums;
using Quasar.scenes.cats;

namespace Quasar.core.goap.actions
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
      
            HaulWorkGoal haulWorkGoal = new();
            HasItemGoal hasItemGoal = new();
            AdjToGoal adjToGoal = new();
            _preconditions.Add(haulWorkGoal);
            _preconditions.Add(adjToGoal);
            _preconditions.Add(hasItemGoal);
        }

        public override void Execute(Cat cat, Blackboard blackboard)
        {
            if (blackboard.TryGetWork(new(WorkType.HAULING.ToString()), out var work))
            {
                cat.SetWork([work]);
            }
        }
    }
}