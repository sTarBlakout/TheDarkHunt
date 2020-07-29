using UnityEngine;
using  UnityEngine.Animations;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private AnimatorOverrideController initialController;
    
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int SimpleAttack = Animator.StringToHash("SimpleAttack");
        
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
        
        private Animator _animator;
        private PlayerMover _playerMover;

        public bool IsInAttackState => _animator.GetBool(IsAttacking);

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMover = GetComponent<PlayerMover>();
            
            _animator.runtimeAnimatorController = initialController;
        }

        private void Update()
        {
            _animator.SetFloat(MoveSpeed, _playerMover.MagnitudeNorm);
        }

        public void SetNewAnimations(AnimatorOverrideController animations)
        {
            if (animations == null) return;
            _animator.runtimeAnimatorController = animations;
        }

        public void ProcessSimpleAttack()
        {
            _animator.SetTrigger(SimpleAttack);
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

