using Godot;
using Quasar.data.enums;
using Quasar.scenes.common.interfaces;
using System.Collections.Generic;

namespace Quasar.scenes.systems.work
{
    public partial class Work(int workId, Vector2 localPos, WorkType workType, List<ICommand> commands, bool isAssigned = false) : Resource
    {
        public int WorkId { get; set; } = workId;

        public bool IsComplete { get => Commands.Count == 0; }

        public bool IsAssigned { get; set; } = isAssigned;

        public Vector2 LocalPos { get; set; } = localPos;

        public WorkType WorkType { get; set; } = workType;

        public List<ICommand> Commands { get; set; } = commands;
    }
}
