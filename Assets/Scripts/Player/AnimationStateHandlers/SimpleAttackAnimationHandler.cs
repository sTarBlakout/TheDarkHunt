using Global;
using UnityEngine;

namespace Player.AnimationStateHandlers
{
    public class SimpleAttackAnimationHandler : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(GlobalAnimationData.IsAttacking, true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(GlobalAnimationData.IsAttacking, false);
        }
    }
}