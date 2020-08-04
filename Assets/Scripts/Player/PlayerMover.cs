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
        [SerializeField] private float moveSpeedCoef = 1f;
        [SerializeField] private float rotateSpeedCoef = 1f;
        [SerializeField] private float smoothDashCoef = 1f;

        private CharacterController _characterController;
        private PlayerController _playerController;

        private Vector3 _targetMovement;
        private Vector3 _currMovement;
        private Quaternion _rotation;
        private float _acceleration;
        private float _deceleration;
        private float _currSpeed;

        private Vector3 _smoothDashDirection;
        private float _smoothDashPower;

        public float MagnitudeNorm => transform.InverseTransformDirection(_currMovement).z / maxMoveSpeed;

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

            _characterController.Move(_currMovement * Time.deltaTime);
        }

        private void DefaultMove()
        {
            if (_playerController.InputVector == Vector3.zero)
            {
                _currSpeed += _deceleration * Time.deltaTime;
                _currSpeed = Mathf.Max(_currSpeed, 0f);
                _targetMovement = _playerController.LastUpVector * _currSpeed;
            }
            else
            {
                _currSpeed += _acceleration * Time.deltaTime;
                _currSpeed = Mathf.Min(_currSpeed, maxMoveSpeed);
                _targetMovement = _playerController.InputVector * _currSpeed;
            }
            _currMovement = Vector3.LerpUnclamped(_currMovement, _targetMovement, moveSpeedCoef);
        }

        private void SmoothDash()
        {
            _currSpeed += _deceleration * Time.deltaTime;
            _currSpeed = Mathf.Max(_currSpeed, 0f);
            _targetMovement = _smoothDashDirection * _currSpeed;
            _currMovement = Vector3.LerpUnclamped(_currMovement, _targetMovement, smoothDashCoef);
        }

        private void UpdateRotation()
        {
            if (_currMovement == Vector3.zero) return;
            
            var rotateTo = Quaternion.LookRotation(_currMovement);
            var step = rotateSpeedCoef * Time.deltaTime;
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
