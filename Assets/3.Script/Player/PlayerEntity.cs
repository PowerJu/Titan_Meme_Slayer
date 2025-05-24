using TMS.Core;
using TMS.Event;
using TMS.Map;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private EntityComponent[] _components;

        private bool _isStopped = true;
        
        private AcquireGameScoreEvent _acquireGameScoreEvent = new AcquireGameScoreEvent(1);

        public static PlayerEntity Me { get; private set; }
        public bool IsPlaying => !_isStopped;


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

            EventBus.Subscribe<PlayStartEvent>(Play);
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
            if (_isStopped)
                return;

            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].ManualUpdate();
            }
            
            // 게임 스코어 습득 이벤트 발행
            EventBus.Publish(_acquireGameScoreEvent);
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

        private void Play(PlayStartEvent @event)
        {
            OnStart();
        }

        public void OnStart()
        {
            _isStopped = false;
            for (int i = 0; i < _components.Length; ++i)
            {
                _components[i].OnPlay();
            }

            GameManager.Instance.StartGame();
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
