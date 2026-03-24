using Catcophony.data.enums;
using Catcophony.scenes.cats;
using Catcophony.scenes.systems.pathing;
using Catcophony.scenes.systems.work;
using System;
using System.Collections.Generic;

namespace Catcophony.scenes.common.interfaces
{
    public interface IWorkSystem
    {
        public bool AssignWork(Work work, bool assign = true);

        public List<Work> GetWork(WorkType workType);

        public List<Work> CheckForWork(WorkType workType);

        public Tuple<List<Work>, Path> CheckForWork(Cat cat, bool assign = true);
    }
}