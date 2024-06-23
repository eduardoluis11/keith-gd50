using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Script for the animator controller of the player character (and possibly the enemy.)

Source of most of this code: 
https://youtu.be/COckHIIO8vk?si=txD3BSuwAvNkY4w3
*/

public class CharacterAnimator : MonoBehaviour {

    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    protected Animator animator;
	protected CharacterCombat combat;

	protected virtual void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		combat = GetComponent<CharacterCombat>();
	}

	protected virtual void Update () {
		float speedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);

		animator.SetBool("inCombat", combat.InCombat);
	}
}
