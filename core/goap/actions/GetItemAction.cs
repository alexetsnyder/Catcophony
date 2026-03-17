using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.core.goap.goals;
using Quasar.core.naming;
using Quasar.data.enums;
using Quasar.scenes.cats;

namespace Quasar.core.goap.actions
{
    public partial class GetItemAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 1; }

        private readonly FastName _name = new("GetItemAction");

        public GetItemAction()
        {
            HasItemGoal hasItemGoal = new();
            _effects.Add(hasItemGoal);

            GetItemGoal getItemGoal = new();
            AdjToGoal adjToGoal = new();
            _preconditions.Add(getItemGoal);
            _preconditions.Add(adjToGoal);
        }

        public override void Execute(Cat cat, Blackboard blackboard)
        {
            if (blackboard.TryGetWork(new(WorkType.GET_ITEM.ToString()), out var work))
            {
                cat.SetWork([work]);
            }
        }
    }
}