using Quasar.core.blackboard;
using Quasar.core.goap.actions;
using Quasar.core.goap.goals;
using Quasar.core.goap.interfaces;
using Quasar.core.naming;
using Quasar.scenes.cats;
using Quasar.scenes.common.interfaces;
using System;
using System.Collections.Generic;

namespace Quasar.core.goap
{
    public class Branch
    {
        public int CumulativeCost { get; set; } = 0;

        public Stack<IAction> Actions { get; set; }
    }

    public partial class Planner
    {
        private WorldState _worldState = null;

        List<IGoal> _goals =
        [
            new WorkGoal(),
        ];

        List<IAction> _availableActions = 
        [
            new Mine(),
            new MoveTo(),
        ];

        public Planner(Cat cat, IWorkSystem workSystem)
        {
            _worldState = new(cat, workSystem);
        }

        //public Stack<IAction> Plan()
        //{
        //    Stack<IAction> actions = [];

        //    if (_worldState != null)
        //    {
        //        var goal = _goals[0];
        //        foreach (var action in _availableActions)
        //        {
        //            var tempBlackboard = new Blackboard(_worldState.GetBlackboard());

        //            action.Excecute(tempBlackboard);

        //            if (goal.Satisfy(tempBlackboard))
        //            {
        //                PlanBranch(goal, action, tempBlackboard);
        //            }
        //        }
        //    }

        //    return actions;
        //}

        //private void PlanBranches(KeyValuePair<FastName, bool> kvp, IAction action, Blackboard blackboard, out List<Branch> branches)
        //{
        //    List<Branch> branchList = [];

        //    Branch branch = new()
        //    {
        //        CumulativeCost = action.Cost,
        //        Actions = []
        //    };

        //    branch.Actions.Push(action);

        //    branchList.Add(branch);
        //}

        //private bool PlanBranch(IAction action, Blackboard blackboard, Branch branch)
        //{
        //    branch.CumulativeCost += action.Cost;
        //    branch.Actions.Push(action);

        //    if (!action.SatisfyPreconds(blackboard))
        //    {
        //        bool allPreCondsSatisfied = false;
        //        foreach (var precond in action.GetPreconds())
        //        {
                    
        //            foreach (var nextAction in _availableActions)
        //            {
        //                Blackboard tempBlackboard = new(blackboard);

        //                action.Excecute(tempBlackboard);

        //                if (!Satisfy(precond, tempBlackboard))
        //                {
        //                    continue;
        //                }


        //            }
        //        }

        //        return allPreCondsSatisfied;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private List<Branch> PlanBranch(IGoal goal, IAction action, Blackboard blackboard)
        //{
        //    List<Branch> branches = [];

        //    Branch branch = new()
        //    {
        //        CumulativeCost = action.Cost,
        //        Actions = []
        //    };

        //    branch.Actions.Push(action);

        //    branches.Add(branch);

        //    if (!action.SatisfyPreconds(blackboard))
        //    {
        //        Stack<KeyValuePair<FastName, bool>> stack = [];

        //        foreach (var precond in action.GetPreconds())
        //        {
        //            stack.Push(precond);
        //        }

        //        while (stack.Count > 0)
        //        {
        //            var precond = stack.Pop();


        //        }

        //        if (!Satisfy(pre, blackboard))
        //        {
        //            foreach (var next in _availableActions)
        //            {
        //                Blackboard tempBlackboard = new(blackboard);

        //                next.Excecute(tempBlackboard);

        //                if (Satisfy(pre, tempBlackboard))
        //                {

        //                }
        //            }
        //        }
        //    }

        //    return branches;
        //}

        private bool Satisfy(KeyValuePair<FastName, bool> kvp, Blackboard blackboard)
        {
            if (blackboard.TryGetBool(kvp.Key, out var value))
            {
                if (kvp.Value == value)
                {
                    return true; 
                }
            }

            return false;
        }
    }
}