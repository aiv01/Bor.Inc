using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkGranadierBehaviour : StateMachineBehaviour
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
        Vector3 from = animator.transform.forward;
        Vector3 to = (mg.Ellen.position - animator.transform.position).normalized;
        float angle = Mathf.Abs(Vector3.SignedAngle(from, to, Vector3.up));

        if ((-animator.transform.position + mg.Ellen.position).sqrMagnitude <= mg.ViewDistance * mg.ViewDistance) {
            if (angle > mg.DetecAngle * 0.5f) {
                mg.TargetPos = animator.transform.position;
            } else {
                mg.TargetPos = mg.Ellen.position;
            }
            animator.SetFloat("Speed", (-animator.transform.position + mg.Ellen.position).sqrMagnitude / (mg.ViewDistance * mg.ViewDistance));
            mg.GetComponent<NavMeshAgent>().speed = mg.speed + (6 * (-animator.transform.position + mg.Ellen.position).sqrMagnitude / (mg.ViewDistance * mg.ViewDistance));
            animator.SetBool("Turn", true);
            return;
        } else {
            mg.TargetPos = mg.SpawnPos;
            if ((-animator.transform.position + mg.SpawnPos).sqrMagnitude <= mg.DistanceFromBase * mg.DistanceFromBase) {
                animator.SetBool("InPursuit", false);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
                //animator.SetBool("InPursuit", false);

    }

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
