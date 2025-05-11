using TMS.Core;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerWire : EntityComponent
    {
        [SerializeField] private Transform _wireObject;
        [SerializeField] private Vector3 _wireOffset = new Vector3(0, 0.5f, 0);
        private readonly string JumpString = "Jump";
        private Vector3 _wirePosition;
        private bool _isWiring;

        public override void ManualUpdate()
        {
            if (_isWiring)
            {
                Vector3 currentPosition = transform.position + _wireOffset;
                Vector3 targetPosition = _wirePosition;
                var magnitude = (targetPosition - currentPosition).magnitude;
                _wireObject.position = (_wirePosition + currentPosition) * 0.5f;
                _wireObject.up = (targetPosition - currentPosition).normalized;
                _wireObject.localScale = new Vector3(0.05f, magnitude * 0.5f, 0.05f);
            }
        }

        public void SetWirePosition(Vector3 wirePosition)
        {
            _wirePosition = wirePosition;
        }

        public void ActiveWire(bool value)
        {
            _isWiring = value;
            _wireObject.gameObject.SetActive(value);
        }
    }
}
