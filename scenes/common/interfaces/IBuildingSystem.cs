using Catcophony.data.enums;
using Catcophony.scenes.systems.building;

namespace Catcophony.scenes.common.interfaces
{
    public interface IBuildingSystem
    {
        public Buildable Current { get; }

        public void SetCurrent(TileType current);

        public void Clear();

        public void NextBuildable();
    }
}