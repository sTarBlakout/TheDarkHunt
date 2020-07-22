using UnityEngine;

namespace Weapons
{
    public class WeaponBase : ScriptableObject
    {
        [Header("Main")] 
        [SerializeField] private string weaponName;
        [SerializeField] private GameObject weaponPrefab;

        public string WeaponName => weaponName;
        public GameObject WeaponPrefab => weaponPrefab;
    }
}