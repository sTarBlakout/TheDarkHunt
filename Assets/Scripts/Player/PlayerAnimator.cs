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
            _animator.SetFloat(MoveSpeed, _playerMover.FrwdSpdNorm);
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

