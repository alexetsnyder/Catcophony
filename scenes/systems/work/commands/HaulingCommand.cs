using Godot;
using Quasar.scenes.cats;
using Quasar.scenes.common.interfaces;

namespace Quasar.scenes.systems.work.commands
{
    public partial class HaulingCommand(IItemSystem itemSystem, ISelectionSystem selectionSystem, Vector2 localPos) : ICommand
    {
        private readonly IItemSystem _itemSystem = itemSystem;

        private readonly ISelectionSystem _selectionSystem = selectionSystem;

        private readonly Vector2 _localPos = localPos;

        public void Execute(Cat cat = null)
        {
            if (cat == null)
            {
                return;
            }

            if (cat.Item == null)
            {
                var items = _itemSystem.GetItems(_localPos);
                if (items.Count > 0)
                {
                    cat.Item = items[0];
                    _itemSystem.PickUpItem(cat.Item);

                    if (items.Count == 1)
                    {
                        _selectionSystem.Deselect(_localPos);
                    }
                }
            }
            else
            {
                _itemSystem.PlaceItem(cat.Item, _localPos);
                cat.Item = null;
            } 
        }
    }
}