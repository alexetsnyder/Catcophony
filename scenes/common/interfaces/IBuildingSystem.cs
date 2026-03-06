using Quasar.data.enums;
using Quasar.scenes.systems.building;

namespace Quasar.scenes.common.interfaces
{
    public interface IBuildingSystem
    {
        public Buildable Current { get; }

        public void SetCurrent(TileType current);

        public void Clear();

        public void NextBuildable();
    }
}