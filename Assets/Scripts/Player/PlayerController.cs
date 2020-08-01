using Global;
using UnityEngine;
using Weapons;
using Player.DataTypes;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private FixedJoystick _fixedJoystick;

        private float _inputX;
        private float _inputZ;
        
        public Vector3 InputVector => new Vector3(_inputX, 0f, _inputZ);
        public Vector3 LastUpVector => new Vector3(_fixedJoystick.LastUpInput.x, 0f, _fixedJoystick.LastUpInput.y);

        private PlayerAnimator _playerAnimator;
        private PlayerFighter _playerFighter;
        private PlayerMover _playerMover;
        private PlayerInventory _playerInventory;

        public MovingState MovingState { get; private set; }

        private void Awake()
        {
            _fixedJoystick = FindObjectOfType<FixedJoystick>();

            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerFighter = GetComponent<PlayerFighter>();
            _playerMover = GetComponent<PlayerMover>();
            _playerInventory = GetComponent<PlayerInventory>();
        }

        private void Update()
        {
            GrabJoystickInput();
            UpdateStates();
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                SimpleAttackBehavior();
            }
        }

        private void UpdateStates()
        {
            MovingState = _playerAnimator.Animator.GetBool(GlobalAnimationData.IsAttacking) ? 
                MovingState.SmoothDash : MovingState.DefaultMove;
        }

        private void GrabJoystickInput()
        {
            _inputX = _fixedJoystick.Horizontal;
            _inputZ = _fixedJoystick.Vertical;
        }

        public void SimpleAttackBehavior()
        {
            if (_playerAnimator.IsInAttackState) return;

            var currWeapon = _playerInventory.EquippedWeapon;
            if (currWeapon == null) return;

            var meleeWeapon = currWeapon as MeleeWeapon;
            if (meleeWeapon != null) 
            {
                _playerFighter.Attack();
                _playerMover.SmoothDash(transform.forward, meleeWeapon.DashPower);
                _playerAnimator.ProcessSimpleAttack();
            }
        }
    }
}
