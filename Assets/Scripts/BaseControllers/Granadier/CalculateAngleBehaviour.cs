using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateAngleBehaviour : StateMachineBehaviour
{
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Turn", false);
        MeleeGranadier mg = animator.GetComponent<MeleeGranadier>();
        Vector3 from = animator.transform.forward;
        Vector3 to = (mg.Ellen.position - animator.transform.position).normalized;
        float angle = Vector3.SignedAngle(from, to, Vector3.up);
        int sign = angle > 0 ? 1 : -1;
        animator.SetFloat("Angle", angle * 0.0055556f);
        angle = Mathf.Abs(angle);
        Debug.Log(angle);
        if (angle > 150) {
            animator.SetTrigger("CloseAreaAttack");
            //animator.SetBool("Turn", true);
            return;
        }else if(angle > mg.DetecAngle)
        {
            animator.SetTrigger("Rotate");
            animator.SetBool("Turn", true);
            return;
        } 
        else if ((mg.Ellen.position - animator.transform.position).sqrMagnitude < mg.AttackDistance * mg.AttackDistance)
        {
            animator.SetTrigger("MeleeAttack");
        }
        else if ((mg.Ellen.position - animator.transform.position).sqrMagnitude > mg.ViewDistance * mg.ViewDistance - mg.AttackDistance)
        {
            animator.SetTrigger("RangeAttack");
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
