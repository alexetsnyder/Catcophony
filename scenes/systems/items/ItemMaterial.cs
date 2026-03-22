using Godot;
using Quasar.data.enums;

namespace Quasar.scenes.systems.items
{
    public partial class ItemMaterial(TileType type, Vector2I atlasCoord, Color color) : Resource
    {
        public TileType Type { get; private set; } = type;

        public Vector2I AtlasCoords { get; private set; } = atlasCoord;

        public Color Color { get; private set; } = color;
    }
}