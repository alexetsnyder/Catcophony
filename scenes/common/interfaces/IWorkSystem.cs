using Quasar.data.enums;
using Quasar.scenes.systems.work;
using System.Collections.Generic;

namespace Quasar.scenes.common.interfaces
{
    public interface IWorkSystem
    {
        public List<Work> GetWork(WorkType workType);
    }
}