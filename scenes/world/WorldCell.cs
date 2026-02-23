using Godot;
using Quasar.data.enums;

namespace Quasar.scenes.world
{
    public partial class WorldCell(TileType tileType, Vector2I atlasCoord, Color modulate, int alternateTile = 0)
    {
        public TileType TileType { get; set; } = tileType;

        public Vector2I AtlasCoord { get; set; } = atlasCoord;

        public Color Modulate { get; set; } = modulate;

        public int AlternateTile { get; set; } = alternateTile;
    }
}