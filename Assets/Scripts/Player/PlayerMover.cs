using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float moveSpeedCoef = 1f;
        [SerializeField] private float rotateSpeedCoef = 1f;
        
        private CharacterController _characterController;
        private PlayerController _playerController;

        private Vector3 _movement;
        private Quaternion _rotation;

        public Vector3 Movement => _movement;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            UpdateMovement();
            UpdateRotation();
        }
        
        private void UpdateMovement()
        {
            _movement = _playerController.InputVector * moveSpeedCoef;
            _characterController.Move(_movement * Time.deltaTime);
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
