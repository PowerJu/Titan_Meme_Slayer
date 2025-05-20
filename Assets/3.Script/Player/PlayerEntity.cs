using TMS.Core;
using TMS.Map;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private EntityComponent[] _components;

        private bool _isStopped = true;

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
            if(Input.GetKeyDown(KeyCode.Space) && _isStopped)
            {
                _isStopped = false;
                GameManager.Instance.StartGame();
                return;
            }

            if (_isStopped)
                return;

            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].ManualUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (_isStopped)
                return;

            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].ManualFixedUpdate();
            }
        }

        public void OnDead()
        {
            _isStopped = true;
            transform.position = MapManager.Instance.SpawnPoint;
            MapManager.Instance.ResetMap();

            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].OnDead();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                OnDead();
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
