using Godot;
using Catcophony.scenes.cats;

namespace Catcophony.scenes.common.interfaces
{
    public interface ICommand
    {
        public void Execute(Cat cat = null);
    }
}