using System;
using UnityEngine;
using Player.DataTypes;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float maxMoveSpeed = 1f;
        [SerializeField] private float timeZeroToMax = 1f;
        [SerializeField] private float timeMaxToZero = 1f;
        [SerializeField] private float rotateSpeed = 1f;

        private CharacterController _characterController;
        private PlayerController _playerController;

        private Vector3 _movement;
        private Quaternion _rotation;
        private float _acceleration;
        private float _deceleration;
        private float _currSpeed;
        
        private Vector3 _smoothDashDirection;
        private float _smoothDashPower;

        public float MagnitudeNorm => transform.InverseTransformDirection(_movement).z / maxMoveSpeed;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Start()
        {
            _acceleration = maxMoveSpeed / timeZeroToMax;
            _deceleration = - maxMoveSpeed / timeMaxToZero;
            
            _smoothDashDirection = Vector3.zero;
        }

        private void Update()
        {
            UpdateMovement();
            UpdateRotation();
        }
        
        private void UpdateMovement()
        {
            switch (_playerController.MovingState)
            {
                case MovingState.DefaultMove:
                {
                    DefaultMove();
                    break;
                }
                case MovingState.SmoothDash:
                {
                    SmoothDash();
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _characterController.Move(_movement * Time.deltaTime);
        }

        private void DefaultMove()
        {
            if (_playerController.InputVector == Vector3.zero)
            {
                _currSpeed += _deceleration * Time.deltaTime;
                _currSpeed = Mathf.Max(_currSpeed, 0f);
                _movement = _playerController.LastUpVector * _currSpeed;
            }
            else
            {
                _currSpeed += _acceleration * Time.deltaTime;
                _currSpeed = Mathf.Min(_currSpeed, maxMoveSpeed);
                _movement = _playerController.InputVector * _currSpeed;
            }
        }

        private void SmoothDash()
        {
            _currSpeed += _deceleration * Time.deltaTime;
            _currSpeed = Mathf.Max(_currSpeed, 0f);
            _movement = _smoothDashDirection * _currSpeed;
        }

        private void UpdateRotation()
        {
            if (_movement == Vector3.zero) return;
            
            var rotateTo = Quaternion.LookRotation(_movement);
            var step = rotateSpeed * Time.deltaTime;
            _rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, step);
            transform.rotation = _rotation;
        }

        public void SmoothDash(Vector3 direction, float power)
        {
            _currSpeed += power;
            _smoothDashDirection = direction;
        }
    }
}
