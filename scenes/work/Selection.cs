using Godot;
using Quasar.data.enums;
using System;
using System.Collections.Generic;

namespace Quasar.scenes.work
{
    public partial class Selection : Resource
    {
        public SelectionState SelectionState { get; set; }

        public List<Vector2> Coords { get; set; }

        public Selection(SelectionState selectionState, List<Vector2> coords) 
        { 
            SelectionState = selectionState;
            Coords = coords;
        }
    }
}
