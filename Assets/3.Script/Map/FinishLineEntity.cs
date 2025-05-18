using TMS.Core;
using TMS.Event;
using TMS.Player;
using UnityEngine;

namespace TMS.Map
{
    public class FinishLineEntity : MonoBehaviour, IInteractable
    {
        public void OnInteract(PlayerEntity player)
        {
            GameManager.Instance.ClearGame();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerEntity player))
            {
                OnInteract(player);
            }
        }
    }
}
