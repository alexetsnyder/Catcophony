using Catcophony.scenes.common.interfaces;
using Catcophony.system;
using Godot;
using System.Collections.Generic;

namespace Catcophony.scenes.systems.pathing
{
    public partial class PathingSystem : Node2D, IPathingSystem
    {
        [Export]
        public Color PathColor { get; set; } = new Color(1.0f, 0.0f, 1.0f, 1.0f);

        [Export]
        public Node WorldNode { get; set; }

        private IWorld _world;

        private int _nextId = 0;

        private IMultiColorTileMapLayer _pathingTileMapLayer;

        private Dictionary<int, Path> _paths = [];

        private AStarGrid2D _aStarGrid2d = new();

        private Vector2I _atlasCoords = Vector2I.Zero;

        private Dictionary<Vector2I, int> _pathReferences = [];

        public override void _Ready()
        {
            _pathingTileMapLayer = GetNode<IMultiColorTileMapLayer>("PathingTileMapLayer");

            GlobalSystem.Instance.LoadInterface<IWorld>(WorldNode, out _world);

            SetUpAStar();
        }

        public Path CreateEmptyPath()
        {
            int pathId = AddPath([]);

            return _paths[pathId];
        }

        public Vector2? ShortestPointWithAdjacent(Vector2 fromPos, List<Vector2> toPosList)
        {
            Vector2? minPoint = null;
            int minPathCount = int.MaxValue;

            foreach (var toPos in toPosList)
            {
                if (fromPos.IsEqualApprox(toPos))
                {
                    return toPos;
                }

                if (_world.IsImpassable(_pathingTileMapLayer.LocalToMap(toPos)))
                {
                    foreach (var adjPos in _world.GetAdjacentTiles(toPos))
                    {
                        if (fromPos.IsEqualApprox(adjPos))
                        {
                            return toPos;
                        }

                        var path = FindPath(fromPos, adjPos);

                        if (path != null && path.Points.Count < minPathCount)
                        {
                            minPathCount = path.Points.Count;
                            minPoint = toPos;
                        }

                        if (path != null)
                        {
                            RemovePath(path.Id);
                        }
                    }
                }
                else
                {
                    var path = FindPath(fromPos, toPos);

                    if (path != null && path.Points.Count < minPathCount)
                    {
                        minPathCount = path.Points.Count;
                        minPoint = toPos;
                    }

                    if (path != null)
                    {
                        RemovePath(path.Id);
                    }
                }
            }

            return minPoint;
        }

        public Path ShortestPath(Vector2 startPos, List<Vector2> toPosList)
        {
            Path shortestPath = null;
            int minPathCount = int.MaxValue;

            foreach (var toPos in toPosList)
            {
                if (startPos.IsEqualApprox(toPos))
                {
                    return new(-1, []);
                }

                var path = FindPath(startPos, toPos);

                if (path == null)
                {
                    continue;
                }
                else if (path.Points.Count < minPathCount)
                {
                    if (shortestPath != null)
                    {
                        RemovePath(shortestPath.Id);
                    }

                    shortestPath = path;
                    minPathCount = path.Points.Count;
                }
                else
                {
                    RemovePath(path.Id);
                }
            }

            return shortestPath;
        }

        public Path FindPath(Vector2 startPos, Vector2 endPos)
        {
            var start = _pathingTileMapLayer.LocalToMap(startPos);
            var end = _pathingTileMapLayer.LocalToMap(endPos);

            var points = _aStarGrid2d.GetPointPath(start, end);

            Queue<Vector2> pointQueue = [];

            foreach ( var point in points )
            {
                pointQueue.Enqueue(point);
            }

            if (pointQueue.Count > 0)
            {
                int pathId = AddPath(pointQueue);

                return _paths[pathId];
            }

            return null;
        }

        public void ShowPath(int id)
        {
            if (_paths.TryGetValue(id, out Path path))
            {
                foreach (var point in path.Points)
                {
                    SelectCell(point, _atlasCoords, PathColor);
                }
            } 
        }

        public int AddPath(Queue<Vector2> pointQueue)
        {
            foreach (var point in pointQueue)
            {
                AddPathReference(point);
            }

            _paths.Add(_nextId, new Path(_nextId, pointQueue));

            return _nextId++;
        }

        public void RemovePath(int id)
        {
            if (_paths.TryGetValue(id, out Path path))
            {
                foreach (var point in path.Points)
                {
                    RemovePathReference(point);

                    if (IsTileSelected(point))
                    {    
                        if (GetPathReferences(point) == 0)
                        {
                            SelectCell(point);
                        }
                    }
                }

                _paths.Remove(id);
            }
        }

        public void SetPointSolid(Vector2 localPos, bool solid = true)
        {
            _aStarGrid2d.SetPointSolid(_pathingTileMapLayer.LocalToMap(localPos), solid);
        }

        private bool IsTileSelected(Vector2 localPos)
        {
            var coords = _pathingTileMapLayer.LocalToMap(localPos);

            return _pathingTileMapLayer.GetCellSourceId(coords) != -1;
        }

        private int GetPathReferences(Vector2 localPos)
        {
            var coords = _pathingTileMapLayer.LocalToMap(localPos);

            if (_pathReferences.TryGetValue(coords, out var count))
            {
                return count;
            }

            return 0;
        }

        private void AddPathReference(Vector2 localPos)
        {
            var coords = _pathingTileMapLayer.LocalToMap(localPos);

            if (_pathReferences.TryGetValue(coords, out int value))
            {
                _pathReferences[coords] = ++value;
            }
            else
            {
                _pathReferences.Add(coords, 1);
            }
        }

        private void RemovePathReference(Vector2 localPos)
        {
            var coords = _pathingTileMapLayer.LocalToMap(localPos);

            if (_pathReferences.TryGetValue(coords, out int value))
            {
                _pathReferences[coords] = --value;
            }
        }

        private void SelectCell(Vector2 localPos, Vector2I? atlasCoords = null, Color? color = null)
        {
            var coords = _pathingTileMapLayer.LocalToMap(localPos);
            _pathingTileMapLayer.SetCell(coords, atlasCoords, color);
        }

        private void SetUpAStar()
        {
            _aStarGrid2d.Region = new Rect2I(0, 0, _world.Rows + 1, _world.Cols + 1);
            _aStarGrid2d.CellSize = _pathingTileMapLayer.TileSize;
            _aStarGrid2d.DefaultComputeHeuristic = AStarGrid2D.Heuristic.Manhattan;
            _aStarGrid2d.DefaultEstimateHeuristic = AStarGrid2D.Heuristic.Manhattan;
            _aStarGrid2d.DiagonalMode = AStarGrid2D.DiagonalModeEnum.Always;
            _aStarGrid2d.Update();

            foreach (var coords in _world.GetAllPoints())
            {
                if (_world.IsImpassable(coords))
                {
                    _aStarGrid2d.SetPointSolid(coords);
                }
            }
        }
    }
}
