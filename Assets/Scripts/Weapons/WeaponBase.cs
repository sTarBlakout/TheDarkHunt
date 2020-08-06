using UnityEngine;

namespace Weapons
{
    public class WeaponBase : ScriptableObject
    {
        [Header("Main")]
        [SerializeField] private string weaponName;
        [SerializeField] private GameObject weaponPrefab;
        [SerializeField] private AnimatorOverrideController animations;
        
        public string WeaponName => weaponName;
        public GameObject WeaponPrefab => weaponPrefab;
        public AnimatorOverrideController Animations => animations;
        
        [Header("Base Stats")]
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;

        public float Damage => damage;
        public float AttackSpeed => attackSpeed;
    }
}