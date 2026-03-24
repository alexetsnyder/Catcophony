using Godot;
using Catcophony.scenes.cats;
using Catcophony.scenes.common.interfaces;

namespace Catcophony.scenes.systems.work.commands
{
    public partial class GatheringCommand(IWorld world, ISelectionSystem selectionSystem, Vector2 localPos) : ICommand
    {
        private readonly IWorld _world = world;

        private readonly ISelectionSystem _selectionSystem = selectionSystem;

        private readonly Vector2 _localPos = localPos;

        public void Execute(Cat cat = null)
        {
            _world.Gather(_localPos);

            _selectionSystem.Deselect(_localPos);
        }
    }
}