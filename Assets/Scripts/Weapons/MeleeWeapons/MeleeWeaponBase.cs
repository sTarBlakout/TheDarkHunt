using UnityEngine;

namespace Weapons.MeleeWeapons
{
    public class MeleeWeaponBase : ScriptableObject
    {
        [Header("Graphics")] 
        [SerializeField] private GameObject weaponPrefab;
            
        [Header("Base Stats")]
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;

        public GameObject WeaponPrefab => weaponPrefab;
        public float Damage => damage;
        public float AttackSpeed => attackSpeed;
    }
}
