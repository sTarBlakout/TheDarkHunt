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

        private GameObject _equippedWeaponObject;

        private PlayerAnimator _playerAnimator;
        
        public WeaponBase EquippedWeapon => equippedWeapon;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Start()
        {
            _equippedWeaponObject = EquipWeapon();
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
