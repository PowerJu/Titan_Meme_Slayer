using UnityEngine;

namespace TMS.Core
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset = new Vector3(0, 2, -10);
        [SerializeField] private float _speed = 10.0f;

        private void FixedUpdate()
        {
            if (_target == null)
                return;

            Vector3 targetPosition = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _speed);
        }
    }
}