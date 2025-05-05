using TMS.Core;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerMovement : EntityComponent
    {
        private readonly string HorizontalString = "Horizontal";
        private readonly string JumpString = "Jump";

        [SerializeField] private float _forwardSpeed = 5f;
        [SerializeField] private float _wireSpeed = 30f;
        [SerializeField] private float _horizontalSpeed = 5f;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _wirePosition;
        private bool _isWiring;

        public Vector3 Velocity { get; private set; }

        public override void Init()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
        }

        public override void ManualUpdate()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            float moveInput = Input.GetAxis(HorizontalString);
            Velocity = new Vector3(moveInput * _horizontalSpeed, 0, _forwardSpeed);
            transform.position += Velocity * Time.deltaTime;
        }

        private void Jump()
        {
            if (Input.GetButtonDown(JumpString))
            {
                _isWiring = true;
                _wirePosition = transform.position + new Vector3(0, 3, 10);
            }

            if (Input.GetButtonUp(JumpString))
            {
                _isWiring = false;
            }

            if (_isWiring)
            {
                Vector3 targetPosition = _wirePosition;
                targetPosition.x = transform.position.x;
                Vector3 direction = (targetPosition - transform.position).normalized;
                float speed = _wireSpeed;

                _rigidbody.AddForce(direction * speed);
            }
        }
    }
}