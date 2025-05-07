using System.Collections.Generic;
using TMS.Core;
using TMS.Player;
using UnityEngine;

namespace TMS.Map
{
    public class MapManager : Singleton<MapManager>
    {
        [SerializeField] private GameObject _loadPrefab;
        [SerializeField] private int _defaultMapCount = 10;
        [SerializeField] private Transform _spwanPointTrans;

        private List<GameObject> _mapPool = new();
        private PlayerEntity _playerEntity;
        private float _lastMapPositionZ = 0f;
        private int _mapIndex = 0;

        public Vector3 SpawnPoint => _spwanPointTrans.position;

        private void Awake()
        {
            for (int i = 0; i < _defaultMapCount; ++i)
            {
                GameObject map = Instantiate(_loadPrefab);
                map.SetActive(false);
                _mapPool.Add(map);
            }
        }

        private void Start()
        {
            _playerEntity = PlayerEntity.Me;
        }

        private void Update()
        {
            if (_playerEntity.transform.position.z > _lastMapPositionZ - 30f)
            {
                GameObject map = _mapPool[_mapIndex++];
                map.transform.position = new Vector3(0, 0, _lastMapPositionZ + 30f);
                map.SetActive(true);
                _lastMapPositionZ += 30f;

                if (_mapIndex >= _mapPool.Count)
                {
                    _mapIndex = 0;
                }
            }
        }

        public void ResetMap()
        {
            _lastMapPositionZ = 0f;
            _mapIndex = 0;
        }
    }
}
