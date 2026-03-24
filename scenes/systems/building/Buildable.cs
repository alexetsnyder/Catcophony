using Godot;
using Catcophony.data.enums;
using Catcophony.scenes.world;

namespace Catcophony.scenes.systems.building
{
    public partial class Buildable(TileType tileType, TileMaterial material) : Resource
    {
        public TileType TileType { get; set; } = tileType;

        public TileMaterial Material { get; set; } = material;
    }
}

