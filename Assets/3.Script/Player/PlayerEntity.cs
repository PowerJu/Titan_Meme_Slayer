using TMS.Core;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private EntityComponent[] _components;

        private void Start()
        {
            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].Init();
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].Dispose();
            }
        }

        private void Update()
        {
            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].ManualUpdate();
            }
        }

        #if UNITY_EDITOR

        private void OnValidate()
        {
            _components = GetComponentsInChildren<EntityComponent>(true);
        }
        #endif
    }
}
