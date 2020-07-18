using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDarkHunt.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float moveSpeedCoef = 1f;
        [SerializeField] private float rotateSpeedCoef = 1f;
        
        private CharacterController _characterController;
        private PlayerController _playerController;

        private Vector3 _movement;
        private Quaternion _rotation;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerController = GetComponent<PlayerController>();
        }

        private void FixedUpdate()
        {
            UpdateMovement();
            UpdateRotation();
        }
        
        private void UpdateMovement()
        {
            _movement = new Vector3(_playerController.InputX, 0f, _playerController.InputZ);
            _characterController.Move(_movement * moveSpeedCoef);
        }
        
        private void UpdateRotation()
        {
            if (_movement == Vector3.zero) return;
            
            var rotateTo = Quaternion.LookRotation(_movement);
            _rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotateSpeedCoef * Time.deltaTime);
            transform.rotation = _rotation;
        }
    }
}
