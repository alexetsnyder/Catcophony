using Godot;

namespace Quasar.scenes.work
{
    public partial class Buildable(Vector2I atlasCoords, Color color) : Resource
    {
        public Vector2I AtlasCoords { get; set; } = atlasCoords;

        public Color Color { get; set; } = color;
    }
}

