using System.Collections.Generic;
using UnityEngine;

namespace TMS.Map
{
    [System.Serializable]
    public class MapObjectData
    {
        public int ObjectId;
        public GameObject ObjectPrefab;
        public Vector3 Position;
    }

    [CreateAssetMenu(fileName = "MapData", menuName = "Scriptable Objects/MapData")]
    public class MapData : ScriptableObject
    {
        [SerializeField] private MapObjectData[] _mapObjects;
        [SerializeField] private float _sightDistance = 10.0f;

        private int _mapObjectIndex;
        private Dictionary<int, Stack<GameObject>> _objectPool = new Dictionary<int, Stack<GameObject>>();

        public void ResetIndex()
        {
            _mapObjectIndex = 0;
        }

        public void InstantiateMapObjects(Vector3 position, Transform parent)
        {
            if (_mapObjectIndex >= _mapObjects.Length)
                return;

            if (CheckInSight(position, _mapObjects[_mapObjectIndex]))
            {
                var obj = Instantiate(GetObjectFromPool(_mapObjects[_mapObjectIndex].ObjectId), parent);
                obj.transform.localPosition = _mapObjects[_mapObjectIndex].Position;
                ++_mapObjectIndex;
            }
        }

        private GameObject GetObjectFromPool(int objectId)
        {
            if (_objectPool.TryGetValue(objectId, out var pool) == false || pool.Count == 0)
            {
                var newObj = Instantiate(_mapObjects[objectId].ObjectPrefab);
                _objectPool[objectId] = new Stack<GameObject>();
                _objectPool[objectId].Push(newObj);
            }

            return _objectPool[objectId].Peek();
        }

        private bool CheckInSight(Vector3 position, MapObjectData mapObject)
        {
            return Vector3.Distance(mapObject.Position, position) <= _sightDistance;
        }
    }
}