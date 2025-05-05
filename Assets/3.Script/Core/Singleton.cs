using UnityEngine;

namespace TMS.Core
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();
                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject(typeof(T).Name);
                        _instance = singleton.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = default;
            }
        }
    }
}
