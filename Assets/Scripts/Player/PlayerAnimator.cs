using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        
        private Animator _animator;
        private PlayerController _playerController;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            ProcessMovingParams();
        }

        private void ProcessMovingParams()
        {
            var localVelocity = transform.InverseTransformDirection(_playerController.InputVector);
            var speed = localVelocity.z;
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

