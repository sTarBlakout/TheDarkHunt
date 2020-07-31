using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Weapons/Melee Weapon", order = 1)]
    public class MeleeWeapon : WeaponBase
    {
        [Header("Features")]
        [SerializeField] private float dashPower;

        public float DashPower => dashPower;
    }
}
