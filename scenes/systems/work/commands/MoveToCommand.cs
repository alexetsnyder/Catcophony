using Catcophony.scenes.cats;
using Catcophony.scenes.common.interfaces;
using Catcophony.scenes.systems.pathing;

namespace Catcophony.scenes.systems.work.commands
{
    public partial class MoveToCommand(Path path) : ICommand
    {
        private readonly Path _path = path;

        public void Execute(Cat cat = null)
        {
            if (cat != null)
            {
                cat.SetPath(_path);
            }
        }
    }
}