using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Weapons/Melee Weapon", order = 1)]
    public class MeleeWeapon : WeaponBase
    {
        [Header("Features")]
        [SerializeField] private float dashPower;

        [Header("Move Sets")] 
        [SerializeField] private string[] moveSets;
        
        public float DashPower => dashPower;

        public List<List<int>> GetMoveSets()
        {
            var moveSetsList = new List<List<int>>();
            foreach (var moveSet in moveSets)
            {
                var attackIds = new List<int>();
                var integers = Regex.Split(moveSet, @"\D+");
                foreach (var value in integers)
                {
                    if (string.IsNullOrEmpty(value)) continue;
                    attackIds.Add(int.Parse(value));
                }
                moveSetsList.Add(attackIds);
            }

            return moveSetsList;
        }
    }
}
