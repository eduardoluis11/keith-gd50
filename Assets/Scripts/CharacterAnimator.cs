using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Script for the animator controller of the player character (and possibly the enemy.)

Source of most of this code: 
https://youtu.be/COckHIIO8vk?si=txD3BSuwAvNkY4w3

Additionally, this script also has code from this video from Brackeys / Sebastian Lague:
https://youtu.be/yhPRkihs-Yg?si=W_x3imWDgruUbED5
*/

public class CharacterAnimator : MonoBehaviour {



	public AnimationClip replaceableAttackAnim;
	public AnimationClip[] defaultAttackAnimSet;
	protected AnimationClip[] currentAttackAnimSet;

    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    protected Animator animator;
	protected CharacterCombat combat;
	protected AnimatorOverrideController overrideController;

	protected virtual void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		combat = GetComponent<CharacterCombat>();

		overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
		animator.runtimeAnimatorController = overrideController;

		currentAttackAnimSet = defaultAttackAnimSet;
		combat.OnAttack += OnAttack;
	}

	protected virtual void Update () {
		float speedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);

		animator.SetBool("inCombat", combat.InCombat);
	}

	protected virtual void OnAttack () {
		animator.SetTrigger("attack");
		int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
		// overrideController[replaceableAttackAnim.name] = currentAttackAnimSet[attackIndex];
		overrideController["Sword Slash 1"] = currentAttackAnimSet[attackIndex];
	}
	
}
