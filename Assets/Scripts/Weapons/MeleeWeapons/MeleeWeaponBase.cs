using UnityEngine;

namespace Weapons.MeleeWeapons
{
    public class MeleeWeaponBase : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;

        public float Damage => damage;
        public float AttackSpeed => attackSpeed;
    }
}
