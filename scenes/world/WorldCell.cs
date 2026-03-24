using Catcophony.data.enums;

namespace Catcophony.scenes.world
{
    public partial class WorldCell(TileType tileType, TileMaterial material)
    {
        public int Id { get; set; } = -1;

        public TileType TileType { get; set; } = tileType;

        public TileMaterial Material { get; set; } = material;
    }
}