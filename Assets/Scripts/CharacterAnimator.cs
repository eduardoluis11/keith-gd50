using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Script for the animator controller of the player character (and possibly the enemy.)

Source of most of this code: 
https://youtu.be/COckHIIO8vk?si=txD3BSuwAvNkY4w3

Additionally, this script also has code from this video from Brackeys / Sebastian Lague:
https://youtu.be/yhPRkihs-Yg?si=W_x3imWDgruUbED5

I also used code from this video From Sebastian Lague: https://youtu.be/aOmqkTdqQXo?si=zIb3Mkeei33Si50q
*/

public class CharacterAnimator : MonoBehaviour {



	public AnimationClip replaceableAttackAnim;
	public AnimationClip[] defaultAttackAnimSet;
	protected AnimationClip[] currentAttackAnimSet;

    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    protected Animator animator;
	protected CharacterCombat combat;
	public AnimatorOverrideController overrideController;

	protected virtual void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		combat = GetComponent<CharacterCombat>();

		if (overrideController == null) {
			overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
		}


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

		// I think this is why only the first sword slash animation plays: I'm hard-coding the name of that animation 
		// instead of looping through all the sword slash animations.
		// overrideController["Sword Slash 1"] = currentAttackAnimSet[attackIndex];

		// I modified the code so that it loops through all sword slash attack animations 
		overrideController[replaceableAttackAnim.name] = currentAttackAnimSet[attackIndex];
	}
	
}
