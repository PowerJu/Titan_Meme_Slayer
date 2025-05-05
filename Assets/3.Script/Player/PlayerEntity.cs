using TMS.Core;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private EntityComponent[] _components;

        public static PlayerEntity Me { get; private set; }

        private void Awake()
        {
            if (Me == null)
            {
                Me = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

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
