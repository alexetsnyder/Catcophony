using Godot;
using Catcophony.data.enums;
using Catcophony.scenes.systems.pathing;
using Catcophony.scenes.systems.work;

namespace Catcophony.core.goap.interfaces
{
    public interface IAgent
    {
        public int Id { get; }

        public Vector2 Position { get; set; }

        public WorkType WorkType { get; }

        public void SetPath(Path path);

        public void SetWork(Work work);
    }
}