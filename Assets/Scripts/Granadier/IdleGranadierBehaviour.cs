using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGranadierBehaviour : StateMachineBehaviour
{
    MeleeGranadier mg;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        mg = animator.GetComponent<MeleeGranadier>();
        if ((-animator.transform.position + mg.Ellen.position).sqrMagnitude <= mg.ViewDistance * mg.ViewDistance) {
            animator.SetBool("Turn", true);
            return;
        }
        if ((-animator.transform.position + mg.SpawnPos).sqrMagnitude <= mg.DistanceFromBase * mg.DistanceFromBase) {
            //animator.SetBool("InPursuit", false);
            mg.TargetPos = animator.transform.position;
            
        } else if ((-animator.transform.position + mg.SpawnPos).sqrMagnitude > mg.DistanceFromBase * mg.DistanceFromBase) {
            animator.SetBool("InPursuit", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
