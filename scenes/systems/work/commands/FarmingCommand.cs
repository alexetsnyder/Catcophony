using Godot;
using Quasar.scenes.cats;
using Quasar.scenes.common.interfaces;

namespace Quasar.scenes.systems.work.commands
{
    public partial class FarmingCommand(IWorld world, IPathingSystem pathingSystem, ISelectionSystem selectionSystem, Vector2 localPos) : ICommand
    {
        private readonly IWorld _world = world;

        private readonly IPathingSystem _pathingSystem = pathingSystem;

        private readonly ISelectionSystem _selectionSystem = selectionSystem;

        private readonly Vector2 _localPos = localPos;

        public void Execute(Cat cat = null)
        {
            _world.Till(_localPos);

            _pathingSystem.SetPointSolid(_localPos, false);

            _selectionSystem.Deselect(_localPos);
        }
    }
}