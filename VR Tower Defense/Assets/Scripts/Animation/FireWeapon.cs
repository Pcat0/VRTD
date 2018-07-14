using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRPlus;

public class FireWeapon : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private bool isTriggerDown = false;
    [Range(0,1)]
    public float pullDistance;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float axis = XRPlusHandler.Right.Trigger;
        isTriggerDown = axis >= pullDistance;
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float axis = XRPlusHandler.Right.Trigger;
        if (axis >= pullDistance) {
            if (!isTriggerDown) {
                animator.SetTrigger("Fire");
            }
        } else {
            isTriggerDown = false;
        }
        
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
