using UnityEngine;

namespace Weapons
{
    public class WeaponBase : ScriptableObject
    {
        [Header("Graphics")] 
        [SerializeField] private GameObject weaponPrefab;

        public GameObject WeaponPrefab => weaponPrefab;
    }
}