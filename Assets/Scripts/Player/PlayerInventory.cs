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
        
        public GameObject EquippedWeapon => _equippedWeapon;
        
        
    }
}
