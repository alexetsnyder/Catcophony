using Godot;
using Quasar.data.enums;

namespace Quasar.scenes.work
{
    public partial class Work(WorkType workType, Vector2 worldPos) : Resource
    {
        public WorkType WorkType { get; set; } = workType;

        public Vector2 WorldPos { get; set; } = worldPos;
    }
}
