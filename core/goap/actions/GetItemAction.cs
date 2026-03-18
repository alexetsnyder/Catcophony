using Quasar.core.goap.goals;
using Quasar.core.naming;
using Quasar.data.enums;

namespace Quasar.core.goap.actions
{
    public partial class GetItemAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 1; }

        private readonly FastName _name = new("GetItemAction");

        public GetItemAction()
        {
            WorkGoal workGoal = new();
            _effects.Add(workGoal);

            HasWorkGoal hasWorkGoal = new(WorkType.GET_ITEM);
            AdjToGoal adjToGoal = new();
            _preconditions.Add(hasWorkGoal);
            _preconditions.Add(adjToGoal);
        }
    }
}