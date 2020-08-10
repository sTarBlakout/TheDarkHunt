using System.Collections.Generic;
using Global;
using UnityEngine;

namespace Player
{
    public class PlayerFighter : MonoBehaviour
    {
        private const float TimeForKeepCurrAtkSet = 0.2f;
        
        private float _timeBetwAtksToKeepSet;
        private float _timeLastAttack;
        private int _currMoveSetId;
        private int _currAtkId;

        private Animator _animator;

        private List<List<int>> _simpleAtkMoveSets;

        public List<List<int>> SimpleAtkMoveSets { set => _simpleAtkMoveSets = value; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _timeBetwAtksToKeepSet = _animator.GetFloat(GlobalAnimationData.SimpleAttackTime) + TimeForKeepCurrAtkSet;
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
