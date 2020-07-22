using UnityEngine;

namespace Weapons
{
    public class MeleeWeapon : WeaponBase
    {
        [Header("Base Stats")]
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;

        public float Damage => damage;
        public float AttackSpeed => attackSpeed;
    }
}
