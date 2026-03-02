using Godot;
using Quasar.data.enums;

namespace Quasar.scenes.work
{
    public partial class Work(int workId, WorkType workType, Vector2 worldPos, Buildable buildable = null) : Resource
    {
        public int WorkId { get; set; } = workId;

        public WorkType WorkType { get; set; } = workType;

        public Vector2 WorldPos { get; set; } = worldPos;

        public Buildable Buildable { get; set; } = buildable;
    }
}
