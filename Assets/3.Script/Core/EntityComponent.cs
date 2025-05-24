using UnityEngine;

namespace TMS.Core
{
    public abstract class EntityComponent : MonoBehaviour
    {
        public virtual void Init()
        {
        }

        public virtual void Dispose()
        {
        }

        public virtual void ManualUpdate() { }
        public virtual void ManualFixedUpdate() { }

        public virtual void OnPlay()
        {
        }

        public virtual void OnDead()
        {
        }
    }
}
