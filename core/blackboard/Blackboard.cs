using Godot;
using Quasar.core.naming;
using Quasar.scenes.systems.items;
using Quasar.scenes.systems.pathing;
using Quasar.scenes.systems.work;
using System.Collections.Generic;

namespace Quasar.core.blackboard
{
    public partial class Blackboard
    {
        private readonly Dictionary<FastName, int> _intValues = [];

        private readonly Dictionary<FastName, float> _floatValues = [];

        private readonly Dictionary<FastName, bool> _boolValues = [];

        private readonly Dictionary<FastName, Vector2> _vector2Values = [];

        private readonly Dictionary<FastName, Work> _workValues = [];

        private readonly Dictionary<FastName, Path> _pathValues = [];

        private readonly Dictionary<FastName, Item> _itemValues = [];

        private readonly Dictionary<FastName, List<Work>> _workListValues = [];

        public Blackboard() { }
        
        public Blackboard(Blackboard blackboard)
        {
            _intValues = new(blackboard._intValues);
            _floatValues = new(blackboard._floatValues);
            _boolValues = new(blackboard._boolValues);
            _vector2Values = new(blackboard._vector2Values);
            _pathValues = new(blackboard._pathValues);
            _itemValues = new(blackboard._itemValues);
            _workListValues = new(blackboard._workListValues);
        }

        public void Set(FastName key, int value)
        {
            _intValues[key] = value;
        }

        public void Set(FastName key, float value)
        {
            _floatValues[key] = value;
        }

        public void Set(FastName key, bool value)
        {
            _boolValues[key] = value;
        }

        public void Set(FastName key, Vector2 value)
        {
            _vector2Values[key] = value;
        }

        public void Set(FastName key, Work value)
        {
            _workValues[key] = value;
        }

        public void Set(FastName key, Path value)
        {
            _pathValues[key] = value;
        }

        public void Set(FastName key, Item value)
        {
            _itemValues[key] = value;
        }

        public void Set(FastName key, List<Work> value)
        {
            _workListValues[key] = value;
        }

        public bool TryGetInt(FastName key, out int value)
        {
            return TryGet(key, _intValues, out value);
        }

        public bool TryGetFloat(FastName key, out float value)
        {
            return TryGet(key, _floatValues, out value);
        }

        public bool TryGetBool(FastName key, out bool value)
        {
            return TryGet(key, _boolValues, out value);
        }

        public bool TryGetVector2(FastName key, out Vector2 value)
        {
            return TryGet(key, _vector2Values, out value);
        }

        public bool TryGetWork(FastName key, out Work value)
        {
            return TryGet(key, _workValues, out value);
        }

        public bool TryGetPath(FastName key, out Path value)
        {
            return TryGet(key, _pathValues,  out value);
        }

        public bool TryGetItem(FastName key, out Item value)
        {
            return TryGet(key, _itemValues, out value);
        }

        public bool TryGetWorkList(FastName key, out List<Work> value)
        {
            return TryGet(key, _workListValues, out value);
        }

        private bool TryGet<T>(FastName key, Dictionary<FastName, T> values, out T value)
        {
            return values.TryGetValue(key, out value);
        }
    }
}