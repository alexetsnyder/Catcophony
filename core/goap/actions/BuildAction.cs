using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.core.goap.goals;
using Quasar.core.naming;
using Quasar.data.enums;
using Quasar.scenes.cats;

namespace Quasar.core.goap.actions
{
    public partial class BuildAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 1; }

        private readonly FastName _name = new("BuildAction");

        public BuildAction()
        {
            WorkGoal workGoal = new();
            _effects.Add(workGoal);

            BuildWorkGoal buildWorkGoal = new();
            HasProfGoal hasProfGoal = new();
            AdjToGoal adjToGoal = new();
            _preconditions.Add(buildWorkGoal);
            _preconditions.Add(hasProfGoal);
            _preconditions.Add(adjToGoal);  
        }

        public override void Execute(Cat cat, Blackboard blackboard)
        {
            if (blackboard.TryGetWork(new(WorkType.BUILDING.ToString()), out var work))
            {
                cat.SetWork([ work ]);
            }
        }
    }
}