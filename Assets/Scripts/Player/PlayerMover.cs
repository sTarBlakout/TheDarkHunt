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
        
        public MovingState movingState;

        private CharacterController _characterController;
        private PlayerController _playerController;

        private Vector3 _movement;
        private Quaternion _rotation;
        private float _acceleration;
        private float _deceleration;
        private float _currSpeed;
        
        private Vector3 _smoothDashDirection;
        private Vector3 _smoothDashDirectionFinal;
        private float _smoothDashPower;
        private float _dashSpeed;

        public float MagnitudeNorm => transform.InverseTransformDirection(_movement).z / maxMoveSpeed;
        public Vector3 SmoothDashDirectionFinal { set => _smoothDashDirectionFinal = value; }


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Start()
        {
            movingState = MovingState.DefaultMove;
            
            _acceleration = maxMoveSpeed / timeZeroToMax;
            _deceleration = - maxMoveSpeed / timeMaxToZero;
            
            _smoothDashDirectionFinal = Vector3.zero;
        }

        private void Update()
        {
            UpdateMovement();
            UpdateRotation(); ;
        }
        
        private void UpdateMovement()
        {
            switch (movingState)
            {
                case MovingState.DefaultMove:
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
                    break;
                }
                case MovingState.SmoothDash:
                {
                    if (_smoothDashDirectionFinal == Vector3.zero)
                    {
                        if (_playerController.InputVector == Vector3.zero)
                            _smoothDashDirectionFinal = (_playerController.LastUpVector + _smoothDashDirection).normalized;
                        else
                            _smoothDashDirectionFinal = (_playerController.InputVector + _smoothDashDirection).normalized;
                    }
                    _dashSpeed += _deceleration * Time.deltaTime;
                    _dashSpeed = Mathf.Max(_dashSpeed, _currSpeed);
                    _movement = _smoothDashDirectionFinal * _dashSpeed;
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _characterController.Move(_movement * Time.deltaTime);
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
            var slowDownCoef = Mathf.Min(1 - _currSpeed / maxMoveSpeed, 0.9f);
            _dashSpeed = _currSpeed * slowDownCoef + power;
            _smoothDashDirection = direction;
        }
    }
}
