using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private AnimatorOverrideController initialController;
    
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int SimpleAttack = Animator.StringToHash("SimpleAttack");
        
        private Animator _animator;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Start()
        {
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

