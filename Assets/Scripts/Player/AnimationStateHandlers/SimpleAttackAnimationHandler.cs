using Global;
using UnityEngine;

namespace Player.AnimationStateHandlers
{
    public class SimpleAttackAnimationHandler : StateMachineBehaviour
    {
        private float _startAttackTime;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(GlobalAnimationData.IsAttacking, true);
            _startAttackTime = Time.time;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(GlobalAnimationData.IsAttacking, false);
            animator.SetFloat(GlobalAnimationData.SimpleAttackTime, Time.time - _startAttackTime);
        }
    }
}