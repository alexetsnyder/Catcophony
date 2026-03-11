using Quasar.core.blackboard;
using Quasar.core.naming;
using System.Collections.Generic;

namespace Quasar.core.goap.interfaces
{
    public interface IAction
    {
        public int Cost { get; set; }

        public Dictionary<FastName, bool> GetPreconds();

        public bool SatisfyPreconds(Blackboard blackboard);

        public void Excecute(Blackboard blackboard);
    }
}