using Godot;
using Quasar.scenes.cats;

namespace Quasar.scenes.common.interfaces
{
    public interface ICommand
    {
        public void Execute(Cat cat = null);
    }
}