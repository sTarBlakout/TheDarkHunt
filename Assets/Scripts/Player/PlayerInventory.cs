using System;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Body Parts Transform")]
        [SerializeField] private Transform rightHandTransform;

        [Header("Equipment")]
        [SerializeField] private WeaponBase equippedWeapon;

        private GameObject _equippedWeapon;

        private PlayerAnimator _playerAnimator;
        
        public GameObject EquippedWeapon => _equippedWeapon;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Start()
        {
            _equippedWeapon = EquipWeapon();
        }

        private GameObject EquipWeapon()
        {
            if (equippedWeapon == null) return null;

            _playerAnimator.SetNewAnimations(equippedWeapon.Animations);
            
            var weaponPrefab = equippedWeapon.WeaponPrefab;
            return weaponPrefab == null ? null : Instantiate(weaponPrefab, rightHandTransform);
        }
    }
}
