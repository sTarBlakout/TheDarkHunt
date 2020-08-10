using Global;
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
        private PlayerFighter _playerFighter;

        public WeaponBase EquippedWeapon => equippedWeapon;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerFighter = GetComponent<PlayerFighter>();
        }

        private void Start()
        {
            _equippedWeaponObject = EquipWeapon();
        }

        private GameObject EquipWeapon()
        {
            if (equippedWeapon == null) return null;

            var meleeWeapon = equippedWeapon as MeleeWeapon;
            if (meleeWeapon != null)
            {
                _playerAnimator.ChangeAnimations(meleeWeapon.Animations);
                _playerAnimator.SetAnimationSpeed(GlobalAnimationData.AttackSpeedMultiplier, meleeWeapon.AttackSpeed);
                _playerFighter.SimpleAtkMoveSets = meleeWeapon.GetMoveSets();
            }
            
            var weaponPrefab = equippedWeapon.WeaponPrefab;
            return weaponPrefab == null ? null : Instantiate(weaponPrefab, rightHandTransform);
        }
    }
}
