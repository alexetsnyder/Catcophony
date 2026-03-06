using Godot;
using Quasar.data;
using Quasar.data.enums;
using Quasar.scenes.cats;
using Quasar.scenes.common.interfaces;

namespace Quasar.scenes.systems.work.commands
{
    public partial class CuttingCommand(IWorld world, IItemSystem itemSystem, IPathingSystem pathingSystem,
                                        ISelectionSystem selectionSystem, Vector2 localPos) : ICommand
    {
        private readonly IWorld _world = world;

        private readonly IItemSystem _itemSystem = itemSystem;

        private readonly IPathingSystem _pathingSystem = pathingSystem;

        private readonly ISelectionSystem _selectionSystem = selectionSystem;

        private readonly Vector2 _localPos = localPos;

        public void Execute(Cat cat = null)
        {
            var color = _world.GetTileColor(_localPos);

            _world.Cut(_localPos);

            _itemSystem.CreateItem(TileType.WOOD, _localPos, color);

            _pathingSystem.SetPointSolid(_localPos, false);

            _selectionSystem.Deselect(_localPos);
        }
    }
}