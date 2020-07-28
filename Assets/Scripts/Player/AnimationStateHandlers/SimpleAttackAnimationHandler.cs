using UnityEngine;
using Player.DataTypes;

namespace Player.AnimationStateHandlers
{
    public class SimpleAttackAnimationHandler : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var playerMover = animator.GetComponent<PlayerMover>();
            playerMover.movingState = MovingState.SmoothDash;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var playerMover = animator.GetComponent<PlayerMover>();
            playerMover.movingState = MovingState.DefaultMove;
            playerMover.SmoothDashDirectionFinal = Vector3.zero;
        }
        
    }
}