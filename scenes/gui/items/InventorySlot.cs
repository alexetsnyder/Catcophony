using Godot;
using Catcophony.scenes.systems.items;

namespace Catcophony.scenes.gui.items
{
    public partial class InventorySlot : Control
    {
        [Export]
        public Texture2D TextureAtlas { get; set; }

        private TextureRect _inventoryIcon;

        private Label _inventoryLabel;

        public override void _Ready()
        {
            _inventoryIcon = GetNode<TextureRect>("%InventoryIcon");
            _inventoryLabel = GetNode<Label>("%InventoryLabel");
        }

        public void Add(Item item)
        {
            _inventoryLabel.Text = item.Material.Type.ToString();

            var atlasCoords = item.Material.AtlasCoords;
            var color = item.Material.Color;

            AtlasTexture atlas = new()
            {
                Atlas = TextureAtlas,
                Region = new(atlasCoords.X * 18.0f, atlasCoords.Y * 18.0f, 18.0f, 18.0f)
            };

            _inventoryIcon.Texture = atlas;

            _inventoryIcon.Modulate = color;
        }
    }
}
