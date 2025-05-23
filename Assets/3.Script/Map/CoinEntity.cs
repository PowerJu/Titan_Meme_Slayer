using TMS.Event;
using TMS.Player;
using UnityEngine;

namespace TMS.Map
{
    public interface IInteractable
    {
        public void OnInteract(PlayerEntity player);
    }

    public class CoinEntity : MonoBehaviour, IInteractable
    {
        [SerializeField] private int _coinScore = 10;

        public void OnInteract(PlayerEntity player)
        {
            if (player == null) return;

            EventBus.Publish(new AcquireCoinEvent(_coinScore));
            Destroy(gameObject);
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