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

        private readonly IAgent _agent;

        private readonly IWorkSystem _workSystem;

        private readonly IPathingSystem _pathingSystem;

        private readonly List<WorkType> _availableWorkTypes =
        [
            WorkType.MINING,
            WorkType.BUILDING,
        ];

        public readonly List<IAction> AvailableActions = [];

        public WorldState(IAgent agent, IWorkSystem workSystem, IPathingSystem pathingSystem) 
        { 
            _agent = agent;
            _workSystem = workSystem;
            _pathingSystem = pathingSystem;

            _blackboard.Set(Constants.Names.Position, _agent.Position);
            _blackboard.Set(Constants.Names.WorkType, (int)_agent.WorkType);

            foreach (var workType in _availableWorkTypes)
            {
                var workList = _workSystem.CheckForWork(workType);
                _blackboard.Set(new(workType.ToString()), workList);
            }

            MoveToAction moveToAction = new(_pathingSystem);
            AvailableActions.Add(moveToAction);

            MineAction mineAction = new();
            AvailableActions.Add(mineAction);

            BuildAction buildAction = new();
            AvailableActions.Add(buildAction);
        }

        public Blackboard GetBlackboard()
        {
            return _blackboard; 
        }
    }
}