using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.core.goap.goals;
using Quasar.core.naming;
using Quasar.scenes.cats;

namespace Quasar.core.goap.actions
{
    public partial class MineAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 1; }

        private readonly FastName _name = new("MineAction");

        public MineAction()
        {
            WorkGoal workGoal = new();
            _effects.Add(workGoal.Key, workGoal);

            AdjToGoal adjToGoal = new();
            MineWorkGoal mineWorkGoal = new();
            _preconditions.Add(adjToGoal.Key, adjToGoal);
            _preconditions.Add(mineWorkGoal.Key, mineWorkGoal);
        }

        public override void Execute(Cat cat, Blackboard blackboard)
        {
            if (blackboard.TryGetWork(Constants.Names.SelectedWork, out var work))
            {
                cat.SetWork([ work ]);
            }
        }
    }
}