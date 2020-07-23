using System;
using UnityEngine;
using Weapons;

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
        }

        private void GrabJoystickInput()
        {
            _inputX = _fixedJoystick.Horizontal;
            _inputZ = _fixedJoystick.Vertical;
        }

        public void AttackBehavior()
        {
            var currWeapon = _playerInventory.EquippedWeapon;
            if (currWeapon == null) return;

            var meleeWeapon = currWeapon as MeleeWeapon;
            if (meleeWeapon != null) 
            {
                _playerFighter.Attack();
                _playerAnimator.ProcessSimpleAttack();
                _playerMover.Dash(transform.forward, meleeWeapon.DashPower);
            }
        }
    }
}
