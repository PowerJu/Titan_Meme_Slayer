using TMS.Core;
using UnityEngine;

namespace TMS.Player
{
    public class PlayerAnimator : EntityComponent
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMovement _playerMovement;

        private static readonly int IsWiring = Animator.StringToHash("IsWiring");

        public override void ManualUpdate()
        {
            UpdateAnimatorParameters();
        }

        private void UpdateAnimatorParameters()
        {
            _animator.SetBool(IsWiring, _playerMovement.IsWiring);
        }
    }
}
