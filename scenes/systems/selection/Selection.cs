using Godot;
using Quasar.data.enums;
using System;
using System.Collections.Generic;

namespace Quasar.scenes.systems.selection
{
    public partial class Selection(SelectionState selectionState, List<Vector2> points) : Resource
    {
        public SelectionState SelectionState { get; set; } = selectionState;

        public List<Vector2> Points { get; set; } = points;
    }
}
