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

        public abstract void ManualUpdate();

    }
}
