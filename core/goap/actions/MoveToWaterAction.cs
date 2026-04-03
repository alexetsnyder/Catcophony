using Catcophony.core.goap.goals;
using Catcophony.core.goap.interfaces;
using Catcophony.core.naming;
using Catcophony.scenes.cats;
using Catcophony.scenes.common.interfaces;
using Catcophony.scenes.systems.work.commands;

namespace Catcophony.core.goap.actions
{
    public partial class MoveToWaterAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 2; }

        public override bool SkipAssign { get => true; }

        private readonly FastName _name = new("MoveToWaterAction");

        private readonly IWorld _world;

        private readonly IPathingSystem _pathingSystem;

        public MoveToWaterAction(IWorld world, IPathingSystem pathingSystem)
        {
            _world = world;
            _pathingSystem = pathingSystem;

            AdjToWaterGoal adjToWaterGoal = new(this, _world);
            _effects.Add(adjToWaterGoal);

            HasPathWaterGoal hasPathWaterGoal = new(this, _world, _pathingSystem);
            _preconditions.Add(hasPathWaterGoal);
        }

        public override void LinkParent(IAction parent)
        {
            base.LinkParent(parent);
            _blackboard = parent.GetBlackboard();
        }

        public override void Execute(Cat cat)
        {
            if (_blackboard.TryGetVector2(Constants.Names.GoalPos, out var goalPos))
            {
                var path = _pathingSystem.ShortestPath(cat.Position, _world.GetAdjacentTiles(goalPos));

                var command = new MoveToCommand(path);
                command.Execute(cat);
            }
        }
    }
}