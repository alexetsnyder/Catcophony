using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.data.enums;
using System.Linq;

namespace Quasar.core.goap.goals
{
    public partial class AdjToGoal : GoalBase
    {
        public AdjToGoal()
        {
            _key = new("AdjTo");
            _value = true;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetVector2(Constants.Names.Position, out var agentPos))
            {
                //if (blackboard.TryGetWork(Constants.Names.SelectedWork, out var selectedWork))
                //{
                //    foreach (var adjPos in selectedWork.AdjPos)
                //    {
                //        if (adjPos.IsEqualApprox(agentPos))
                //        {
                //            return true;
                //        }
                //    }
                //}
                if (blackboard.TryGetInt(Constants.Names.CurrentWorkType, out var currentWorkTypeInt))
                {
                    var currentWorkType = (WorkType)currentWorkTypeInt;

                    if (blackboard.TryGetWork(new(currentWorkType.ToString()), out var currentWork))
                    {
                        foreach (var adjPos in currentWork.AdjPos)
                        {
                            if (adjPos.IsEqualApprox(agentPos))
                            {
                                return true;
                            }
                        }
                    }

                    if (blackboard.TryGetWorkList(new(currentWorkType.ToString()), out var workList))
                    {
                        if (workList.Count > 0)
                        {
                            foreach (var work in workList.ToDictionary(w => w, w => w.AdjPos ?? []))
                            {
                                foreach (var adjPos in work.Value)
                                {
                                    if (adjPos.IsEqualApprox(agentPos))
                                    {
                                        blackboard.Set(new(currentWorkType.ToString()), work.Key);
                                        return true;
                                    }
                                }

                            }
                        }
                    }
                } 
            }

            return false;
        }
    }
}