using Godot;
using Quasar.data.enums;
using Quasar.scenes.world;

namespace Quasar.scenes.systems.building
{
    public partial class Buildable(TileType tileType, TileMaterial material) : Resource
    {
        public TileType TileType { get; set; } = tileType;

        public TileMaterial Material { get; set; } = material;
    }
}

