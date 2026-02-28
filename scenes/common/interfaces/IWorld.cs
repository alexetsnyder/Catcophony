using Godot;

namespace Quasar.scenes.common.interfaces
{
    public interface IWorld
    {
        public bool IsInBounds(Vector2I coords);

        public bool IsSolid(Vector2I coords);

        public bool IsImpassable(Vector2I coords);

        public bool IsWater(Vector2I coords);
    }
}