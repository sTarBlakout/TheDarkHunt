using UnityEngine;
using Global;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private AnimatorOverrideController initialController;

        private Animator _animator;
        private PlayerMover _playerMover;

        public bool IsInAttackState => _animator.GetBool(GlobalAnimationData.IsAttacking);
        public Animator Animator => _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMover = GetComponent<PlayerMover>();
            
            _animator.runtimeAnimatorController = initialController;
        }

        private void Update()
        {
            _animator.SetFloat(GlobalAnimationData.MoveSpeed, _playerMover.MagnitudeNorm);
        }

        public void SetNewAnimations(AnimatorOverrideController animations)
        {
            if (animations == null) return;
            _animator.runtimeAnimatorController = animations;
        }

        public void ProcessSimpleAttack(int id)
        {
            _animator.SetInteger(GlobalAnimationData.SimpleAttackId, id);
            _animator.SetTrigger(GlobalAnimationData.SimpleAttack);
        }

        #region Animation Events

        private void FootR()
        {
            
        }
        
        private void FootL()
        {
            
        }

        private void Hit()
        {
            
        }

        #endregion
    }
}

