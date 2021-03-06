﻿using UnityEngine;
using System.Collections;

public class Reset : StateMachineBehaviour {
    private GameObject capsule;
    private Renderer[] rend;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

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

    private void OnStateEnter()
    {
        capsule = GameObject.Find("gachacapsule_animation");
        capsule.transform.position = new Vector3(-1.5f, 0.53f, 1.5f);
        rend =  capsule.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material.color = new Color(Random.Range(0, 100) * .01f, Random.Range(0, 100) * .01f, Random.Range(0, 100) * .01f);
        }
    }
   
}
