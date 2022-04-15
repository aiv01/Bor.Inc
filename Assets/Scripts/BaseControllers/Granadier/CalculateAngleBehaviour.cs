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
        animator.SetFloat("Angle", angle * 0.0055556f);
        angle = Mathf.Abs(angle);
        if (angle > 150) {
            animator.SetTrigger("CloseAreaAttack");
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
}
