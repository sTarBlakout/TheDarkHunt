using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Weapons/Melee Weapon", order = 1)]
    public class MeleeWeapon : WeaponBase
    {
        [Header("Fetures")]
        [SerializeField] private float dashPower;

        public float DashPower => dashPower;
    }
}
