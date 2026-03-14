using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.core.goap.actions;
using Quasar.core.goap.interfaces;
using Quasar.data.enums;
using Quasar.scenes.cats;
using Quasar.scenes.common.interfaces;
using System.Collections.Generic;

namespace Quasar.core.goap
{
    public partial class WorldState
    {
        private readonly Blackboard _blackboard = new();

        private readonly Cat _cat;

        private readonly IWorkSystem _workSystem;

        private readonly IPathingSystem _pathingSystem;

        private readonly List<WorkType> _availableWorkTypes =
        [
            WorkType.MINING,
        ];

        public readonly List<IAction> AvailableActions = [];

        public WorldState(Cat cat, IWorkSystem workSystem, IPathingSystem pathingSystem) 
        { 
            _cat = cat;
            _workSystem = workSystem;
            _pathingSystem = pathingSystem;

            _blackboard.Set(Constants.Names.Position, _cat.Position);

            MoveToAction moveToAction = new(WorkType.MINING, _workSystem, _pathingSystem);
            AvailableActions.Add(moveToAction);

            MineAction mineAction = new(WorkType.MINING, _workSystem);
            AvailableActions.Add(mineAction);
        }

        public Blackboard GetBlackboard()
        {
            return _blackboard; 
        }
    }
}