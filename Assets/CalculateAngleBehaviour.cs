using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateAngleBehaviour : StateMachineBehaviour
{
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MeleeGranadier mg = animator.GetComponent<MeleeGranadier>();
        float angle = Vector3.Angle(mg.TargetPos - animator.transform.position, animator.transform.forward);
        animator.SetFloat("Angle", angle * 0.0055556f);
        if(angle < mg.DetecAngle)
        {
            animator.SetBool("Turn", true);
            return;
        }
        else if (mg.AttackDistance * mg.AttackDistance > (mg.TargetPos - animator.transform.position).sqrMagnitude)
        {
            animator.SetTrigger("MeleeAttack");
        }
        else
        {
            animator.SetBool("InPursuit", true);
        }
        animator.SetBool("Turn", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
