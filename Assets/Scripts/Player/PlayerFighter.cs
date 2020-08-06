using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerFighter : MonoBehaviour
    {
        private List<List<int>> _simpleAtkMoveSets;

        public List<List<int>> SimpleAtkMoveSets { set => _simpleAtkMoveSets = value; }

        public int SimpleAttack()
        {
            var randomMoveSet = Random.Range(0, _simpleAtkMoveSets.Count);
            var randomAtkId = Random.Range(0, _simpleAtkMoveSets[randomMoveSet].Count);

            return _simpleAtkMoveSets[randomMoveSet][randomAtkId];
        }
    }
}
