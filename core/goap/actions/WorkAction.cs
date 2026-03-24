using Catcophony.core.goap.goals;
using Catcophony.core.naming;
using Catcophony.data.enums;

namespace Catcophony.core.goap.actions
{
    public partial class WorkAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => _cost; }

        public readonly FastName _name;
        
        public readonly int _cost;

        private readonly WorkType _workType;

        public WorkAction(FastName name, int cost, WorkType workType)
        {
            _name = name;
            _cost = cost;
            _workType = workType;

            WorkGoal workGoal = new();
            _effects.Add(workGoal);

            HasWorkGoal hasWorkGoal = new(_workType, this);
            HasProfGoal hasProfGoal = new(this);
            AdjToGoal adjToGoal = new(this);
            _preconditions.Add(hasWorkGoal);
            _preconditions.Add(hasProfGoal);
            _preconditions.Add(adjToGoal);
        }
    }
}