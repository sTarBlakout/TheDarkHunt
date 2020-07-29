using UnityEngine;
using Player.DataTypes;

namespace Player.AnimationStateHandlers
{
    public class SimpleAttackAnimationHandler : StateMachineBehaviour
    {
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(IsAttacking, true);
            var playerMover = animator.GetComponent<PlayerMover>();
            playerMover.movingState = MovingState.SmoothDash;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(IsAttacking, false);
            var playerMover = animator.GetComponent<PlayerMover>();
            playerMover.movingState = MovingState.DefaultMove;
            playerMover.SmoothDashDirectionFinal = Vector3.zero;
        }
        
    }
}