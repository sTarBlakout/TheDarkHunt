using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDarkHunt.Player
{
    public class PlayerController : MonoBehaviour
    {
        private FixedJoystick _fixedJoystick;

        private float _inputX;
        private float _inputZ;

        public float InputX => _inputX;
        public float InputZ => _inputZ;
        
        private void Awake()
        {
            _fixedJoystick = FindObjectOfType<FixedJoystick>();
        }

        private void Update()
        {
            GrabInput();
        }

        private void GrabInput()
        {
            _inputX = _fixedJoystick.Horizontal;
            _inputZ = _fixedJoystick.Vertical;
        }
    }
}
