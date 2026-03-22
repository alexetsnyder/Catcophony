using Godot;

namespace Quasar.scenes.systems.items
{
    public partial class Item(int iD, ItemMaterial material, Vector2 position) : Resource
    {
        public int ID { get; set; } = iD;

        public ItemMaterial Material { get; set; } = material;

        public Vector2 Position { get; set; } = position;
    }
}