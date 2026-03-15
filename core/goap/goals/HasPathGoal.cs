using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.data.enums;
using Quasar.scenes.common.interfaces;
using System.Linq;

namespace Quasar.core.goap.goals
{
    public partial class HasPathGoal : GoalBase
    {
        private readonly IPathingSystem _pathingSystem;

        public HasPathGoal(IPathingSystem pathingSystem)
        {
            _key = new("HasPath");
            _value = true;

            _pathingSystem = pathingSystem;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetVector2(Constants.Names.Position, out var agentPos))
            {
                if (blackboard.TryGetPath(Constants.Names.SelectedPath, out var selectedPath))
                {
                    return true;
                }

                if (blackboard.TryGetWork(Constants.Names.SelectedWork, out var selectedWork))
                {
                    foreach (var adjPos in selectedWork.AdjPos)
                    {
                        if (adjPos.IsEqualApprox(agentPos))
                        {
                            blackboard.Set(Constants.Names.SelectedPath, _pathingSystem.CreateEmptyPath());
                            return true;
                        }

                        var path = _pathingSystem.FindPath(agentPos, adjPos);
                        if (path != null)
                        {
                            blackboard.Set(Constants.Names.SelectedPath, path);
                            return true;
                        }
                    }
                }

                if (blackboard.TryGetInt(Constants.Names.SelectedWorkType, out var workTypeInt))
                {
                    var workType = (WorkType)workTypeInt;

                    if (blackboard.TryGetWorkList(new(workType.ToString()), out var workList))
                    {
                        if (workList.Count > 0)
                        {
                            foreach (var work in workList.ToDictionary(w => w, w => w.AdjPos ?? []))
                            {
                                foreach (var adjPos in work.Value)
                                {
                                    if (agentPos.IsEqualApprox(adjPos))
                                    {
                                        blackboard.Set(Constants.Names.SelectedWork, work.Key);
                                        blackboard.Set(Constants.Names.SelectedPath, _pathingSystem.CreateEmptyPath());
                                        return true;
                                    }

                                    var path = _pathingSystem.FindPath(agentPos, adjPos);
                                    if (path != null)
                                    {
                                        blackboard.Set(Constants.Names.SelectedWork, work.Key);
                                        blackboard.Set(Constants.Names.SelectedPath, path);
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