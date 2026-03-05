using Godot;
using Quasar.scenes.systems.pathing;
using System.Collections.Generic;

namespace Quasar.scenes.common.interfaces
{
    public interface IPathingSystem
    {
        public Path CreateEmptyPath();

        public Path ShortestPath(Vector2 startPos, List<Vector2> toPosList);

        public Path FindPath(Vector2 startPos, Vector2 endPos);

        public void ShowPath(int id);

        public void RemovePath(int id);

        public void SetPointSolid(Vector2 localPos, bool solid = true);
    }
}