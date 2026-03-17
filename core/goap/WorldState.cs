using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.core.goap.actions;
using Quasar.core.goap.interfaces;
using Quasar.data.enums;
using Quasar.scenes.common.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quasar.core.goap
{
    public partial class WorldState
    {
        private readonly Blackboard _blackboard = new();

        private readonly IAgent _agent;

        private readonly IWorkSystem _workSystem;

        private readonly IPathingSystem _pathingSystem;

        private IItemSystem _itemSystem;

        private readonly List<WorkType> _availableWorkTypes =
        [
            WorkType.MINING,
            WorkType.BUILDING,
        ];

        public readonly List<IAction> AvailableActions = [];

        public WorldState(IAgent agent, IWorkSystem workSystem, IPathingSystem pathingSystem, IItemSystem itemSystem) 
        { 
            _agent = agent;
            _workSystem = workSystem;
            _pathingSystem = pathingSystem;
            _itemSystem = itemSystem;

            _blackboard.Set(Constants.Names.Position, _agent.Position);
            _blackboard.Set(Constants.Names.AgentWorkType, (int)_agent.WorkType);
            var item = _itemSystem.GetInventoryItems(_agent.Id).FirstOrDefault();

            if (item != null)
            {
                _blackboard.Set(Constants.Names.Item, item);
            }
            
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