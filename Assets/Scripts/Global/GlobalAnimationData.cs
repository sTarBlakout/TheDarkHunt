﻿using System;
using UnityEngine;
using Weapons;

namespace Global
{
    public class GlobalAnimationData : MonoBehaviour
    {
        #region Data

        public static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        public static readonly int SimpleAttack = Animator.StringToHash("SimpleAttack");
        public static readonly int SimpleAttackId = Animator.StringToHash("SimpleAttackID");
        public static readonly int AttackSpeedMultiplier = Animator.StringToHash("AttackSpeedMultiplier");
        
        public static readonly int IsAttacking = Animator.StringToHash("isAttacking");
        public static readonly int SimpleAttackTime = Animator.StringToHash("simpleAttackTime");

        #endregion

        #region Singleton
        
        private static GlobalAnimationData  _instance;
        public static GlobalAnimationData  Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = FindObjectOfType<GlobalAnimationData>();
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }
        
        #endregion
    }
}
