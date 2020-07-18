using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private FixedJoystick _fixedJoystick;

        private float _inputX;
        private float _inputZ;
        
        public Vector3 InputVector => new Vector3(_inputX, 0f, _inputZ);

        private void Awake()
        {
            _fixedJoystick = FindObjectOfType<FixedJoystick>();
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
    }
}
