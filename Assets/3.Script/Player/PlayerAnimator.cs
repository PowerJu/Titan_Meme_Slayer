using TMS.Core;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerAnimator : EntityComponent
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMovement _playerMovement;

        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        public override void ManualUpdate()
        {
            UpdateAnimatorParameters();
        }

        private void UpdateAnimatorParameters()
        {
            _animator.SetBool(IsRunning, Mathf.Abs(_playerMovement.Velocity.z) > 0.1f);
        }
    }
}
