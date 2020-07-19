using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        
        private Animator _animator;
        private PlayerMover _playerMover;
        

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            ProcessMovingParams();
        }

        private void ProcessMovingParams()
        {
            var localVelocity = transform.InverseTransformDirection(_playerMover.Movement);
            var speed = localVelocity.z / _playerMover.MaxMoveSpeed;
            _animator.SetFloat(MoveSpeed, speed);
        }
        
        #region Animation Events

        private void FootR()
        {
            
        }
        
        private void FootL()
        {
            
        }

        #endregion
    }
}

