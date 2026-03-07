using Godot;
using Quasar.data;
using Quasar.scenes.systems.items;

namespace Quasar.scenes.gui.items
{
    public partial class InventoryControl : Control
    {
        [Export]
        public Texture2D AtlasTexture { get; set; }

        private ItemList _inventoryItemList;

        public override void _Ready()
        {
            _inventoryItemList = GetNode<ItemList>("InventoryItemList");

            _inventoryItemList.Clear();
        }

        public void Add(Item item)
        {
            var atlasTexture = CreateAtlasTexture(item);

            _inventoryItemList.AddItem(item.TileType.ToString(), atlasTexture);
        }

        public AtlasTexture CreateAtlasTexture(Item item)
        {
            AtlasTexture atlasTexture = new();

            atlasTexture.Atlas = this.AtlasTexture;

            var atlasCoords = AtlasConstants.GetAtlasCoords(item.TileType);

            atlasTexture.Region = new(atlasCoords.X * 18.0f, atlasCoords.Y * 18.0f, 18.0f, 18.0f);

            return atlasTexture;
        }
    }
}

