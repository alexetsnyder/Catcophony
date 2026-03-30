using Catcophony.core.naming;
using Godot;
using System;

namespace Catcophony.core.goap.actions
{
    public partial class DrinkAction : ActionBase
    {
        public override FastName Name { get => _name; }

        public override int Cost { get => 1; }

        private readonly FastName _name = new("DrinkAction");

        public DrinkAction()
        {

        }
    }
}