using Godot;
using Quasar.data.enums;
using Quasar.scenes.cats;
using Quasar.scenes.common.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quasar.scenes.work
{
    [GlobalClass]
    public partial class WorkSystem : Node
    {
        [Export]
        public Node PathingSystemNode { get; set; }

        [Export]
        public Node WorldNode { get; set; }

        private IPathingSystem _pathingSystem;

        private IWorld _world;

        private int _nextId = 0;

        private readonly Dictionary<WorkType, Dictionary<int, Work>> _allWork = [];

        public override void _Ready()
        {
            LoadInterface<IPathingSystem>(PathingSystemNode, out  _pathingSystem);
            LoadInterface<IWorld>(WorldNode, out _world);
        }

        public override void _Process(double delta)
        {
        }

        public Work GetWork(Vector2 worldPos)
        {
            var workTuple = FindWorkFromPos(worldPos);
            if (workTuple != null)
            {
                return _allWork[workTuple.Item1][workTuple.Item2];
            }

            return null;
        }

        public void CreateWork(WorkType workType, List<Vector2> worldPosList)
        {
            _allWork.TryAdd(workType, []);
            
            foreach (var worldPos in worldPosList)
            {
                _allWork[workType].Add(_nextId, new(_nextId++, workType, worldPos));
            }
        }

        public void RemoveWork(Work work)
        {
            _allWork[work.WorkType].Remove(work.WorkId);
        }

        public void RemoveWork(List<Vector2> worldPosList)
        {
            List<Tuple<WorkType, int>> removeList = [];

            foreach (var worldPos in worldPosList)
            {
                var work = FindWorkFromPos(worldPos);
                if (work != null)
                {
                    removeList.Add(work);
                }
            }

            foreach (var work in removeList)
            {
                _allWork[work.Item1].Remove(work.Item2);
            }
        }

        private Tuple<WorkType, int> FindWorkFromPos(Vector2 worldPos)
        {
            foreach (var workDict in _allWork.Values)
            {
                foreach (var work in workDict.Values)
                {
                    if (work.WorldPos == worldPos)
                    {
                        return new(work.WorkType, work.WorkId);
                    }
                }
            }

            return null;
        }

        public Tuple<Work, Path> CheckForWork(Cat cat)
        {
            var workType = cat.CatData.WorkType;

            if (_allWork.TryGetValue(workType, out Dictionary<int, Work> workDict))
            {
                if (workDict.Count > 0)
                {
                    var path = ShortestPath([.. workDict.Values.Select(w => w)], cat, out Work work);
                    if (work != null)
                    {
                        return new(work, path);
                    }
                }
            }

            return null;
        }

        private Path ShortestPath(List<Work> workList, Cat cat, out Work work)
        {
            Path shortestPath = null;
            int minPathCount = int.MaxValue;
            work = null;

            foreach (var pWork in workList)
            {
                foreach (var adjPos in _world.GetAdjacentTiles(pWork.WorldPos, true))
                {
                    if (cat.Position.IsEqualApprox(adjPos))
                    {
                        work = pWork;
                        return _pathingSystem.CreateEmptyPath();
                    }

                    var path = _pathingSystem.FindPath(cat.Position, adjPos);

                    if (path.Points.Count == 0)
                    {
                        continue;
                    }

                    if (path.Points.Count < minPathCount)
                    {
                        work = pWork;
                        minPathCount = path.Points.Count;
                        shortestPath = path;
                    }
                }
            }

            return shortestPath;
        }

        private void LoadInterface<T>(Node node, out T toInterface)
        {
            toInterface = default;

            if (node is T tempInterface)
            {
                toInterface = tempInterface;
            }
            else
            {
                Quit(1, $"Failed to Load Interface: {typeof(T)}");
            }
        }

        private void Quit(int exitCode, string errorMessage = "")
        {
            if (errorMessage != "")
            {
                GD.Print(errorMessage);
            }

            GetTree().Quit(exitCode);
        }
    }
}
