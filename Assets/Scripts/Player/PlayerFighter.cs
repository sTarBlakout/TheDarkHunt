using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerFighter : MonoBehaviour
    {
        private float _timeBetwAtksToKeepSet;
        private float _timeLastAttack;
        private int _currMoveSetId;
        private int _currAtkId;

        private List<List<int>> _simpleAtkMoveSets;

        public List<List<int>> SimpleAtkMoveSets { set => _simpleAtkMoveSets = value; }
        
        public float TimeBetwAtksToKeepSet
        {
            get => _timeBetwAtksToKeepSet;
            set => _timeBetwAtksToKeepSet = value;
        }

        public int SimpleAttack()
        {
            if (Time.time - _timeLastAttack < _timeBetwAtksToKeepSet &&
                _currAtkId < _simpleAtkMoveSets[_currMoveSetId].Count - 1)
            {
                _currAtkId++;
            }
            else
            {
                _currMoveSetId = Random.Range(0, _simpleAtkMoveSets.Count);
                _currAtkId = 0;
            }
            _timeLastAttack = Time.time;

            return _simpleAtkMoveSets[_currMoveSetId][_currAtkId];
        }
    }
}
