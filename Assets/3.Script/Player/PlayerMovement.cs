using DG.Tweening;
using TMS.Core;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerMovement : EntityComponent
    {
        private readonly string HorizontalString = "Horizontal";
        private readonly string JumpString = "Jump";

        [SerializeField] private Transform _modelTransform;
        [SerializeField] private float _forwardSpeed = 5f;
        [SerializeField] private float _horizontalSpeed = 5f;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private Rigidbody _rigidbody;
        [Header("Wire")]
        [SerializeField] private float _wireSpeed = 30f;
        [SerializeField] private float _minWireDistance = 2.0f;
        [SerializeField] private float _maxWireDistance = 10.0f;
        [SerializeField] private float _maxWireHeight = 30.0f;
        [SerializeField] private Vector3 _wireDirection = new Vector3(0, 1, 5);


        private SpringJoint _joint;
        private PlayerWire _playerWire = null;
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private Vector3 _wirePosition;
        private bool _isWiring;

        public Vector3 Velocity { get; private set; }

        public override void Init()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }

            _playerWire ??= GetComponent<PlayerWire>();
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
            if (Input.GetButtonDown(JumpString) && transform.position.y < _maxWireHeight)
            {
                _isWiring = true;
                var wireDistZ = Random.Range(_minWireDistance, _maxWireDistance);

                _startPosition = transform.position;
                _endPosition = _startPosition + Vector3.forward * wireDistZ;
                _wirePosition = (_startPosition + _endPosition) * 0.5f + new Vector3(0, wireDistZ, 0);

                _joint = gameObject.AddComponent<SpringJoint>();
                _joint.autoConfigureConnectedAnchor = false;
                _joint.connectedAnchor = _wirePosition;
                _joint.maxDistance = Vector3.Distance(transform.position, _wirePosition);
                _joint.minDistance = _joint.maxDistance * 0.95f;
                _joint.spring = 10.0f;
                _joint.damper = 0.5f;
                _joint.enableCollision = false;

                _playerWire.SetWirePosition(_wirePosition);
                _playerWire.ActiveWire(true);
            }

            if (Input.GetButtonUp(JumpString))
            {
                Destroy(_joint);
                _isWiring = false;
                _rigidbody.useGravity = true;
                var velocity = _rigidbody.linearVelocity;
                velocity.x = 0.0f;
                _rigidbody.linearVelocity = velocity;
                _playerWire.ActiveWire(false);
            }

            if (_isWiring)
                _modelTransform.up = _wirePosition - transform.position;
            else
                _modelTransform.up = Vector3.up;
        }

        private void FixedUpdate()
        {
            if (_isWiring)
            {
                // Vector3 targetPosition = _wirePosition;
                // targetPosition.x = transform.position.x;
                float direction = _wirePosition.z - transform.position.z;
                if (direction < 0)
                    return;
                float speed = _wireSpeed * direction;

                _rigidbody.AddForce(Vector3.forward * speed);
            }
        }

        public override void OnDead()
        {
            base.OnDead();
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}