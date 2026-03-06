using Godot;
using Quasar.data.enums;
using Quasar.scenes.common.interfaces;
using Quasar.system;

namespace Quasar.scenes.systems.work.commands
{
    [GlobalClass]
    public partial class CommandFactory : Node
    {
        [Export]
        public Node WorldNode { get; set; }

        [Export]
        public Node PathingSystemNode { get; set; }

        [Export]
        public Node ItemSystemNode { get; set; }

        [Export]
        public Node BuildingSystemNode { get; set; }

        private IWorld _world;

        private IPathingSystem _pathingSystem;

        private IItemSystem _itemSystem;

        private IBuildingSystem _buildingSystem;

        public override void _Ready()
        {
            GlobalSystem.Instance.LoadInterface<IWorld>(WorldNode, out _world);
            GlobalSystem.Instance.LoadInterface<IPathingSystem>(PathingSystemNode, out _pathingSystem);
            GlobalSystem.Instance.LoadInterface<IItemSystem>(ItemSystemNode, out _itemSystem);
            GlobalSystem.Instance.LoadInterface<IBuildingSystem>(BuildingSystemNode, out _buildingSystem);
        }

        public ICommand CreateMiningCommand(Vector2 localPos)
        {
           return new MiningCommand(_world, _itemSystem, _pathingSystem, localPos, TileType.STONE);
        }

        public ICommand CreateBuildingCommand(Vector2 localPos)
        {
            return new BuildingCommand(_world, _pathingSystem, localPos, _buildingSystem.Current);
        }
    }
}