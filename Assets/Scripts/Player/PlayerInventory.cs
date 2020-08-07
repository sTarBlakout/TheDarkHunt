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

        private const float AddTimeForAtkSet = 0.2f;

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
                _playerFighter.SimpleAtkMoveSets = meleeWeapon.GetMoveSets();
                _playerFighter.TimeBetwAtksToKeepSet = meleeWeapon.AttackSpeed + AddTimeForAtkSet;
            }
            
            var weaponPrefab = equippedWeapon.WeaponPrefab;
            return weaponPrefab == null ? null : Instantiate(weaponPrefab, rightHandTransform);
        }
    }
}
