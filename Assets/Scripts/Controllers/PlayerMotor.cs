using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player.
		- If we have a focus move towards that.
		- If we don't move to the desired point.

Most of the code from this file comes from this file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Controllers/PlayerMotor.cs
*/

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour {

	Transform target;

	// I changed this variable's name
	NavMeshAgent playerNavMeshAgent;     // Reference to our NavMeshAgent

	void Start ()
	{
		playerNavMeshAgent = GetComponent<NavMeshAgent>();
		// GetComponent<PlayerController>().onFocusChangedCallback += OnFocusChanged;
	}

	public void MoveToPoint (Vector3 point)
	{
		playerNavMeshAgent.SetDestination(point);
	}

	public void FollowTarget (Interactable newTarget)
	{
		// playerNavMeshAgent.stoppingDistance = newTarget.radius * .8f;
		playerNavMeshAgent.stoppingDistance = newTarget.interactionRadius * .8f;
		playerNavMeshAgent.updateRotation = false;

		target = newTarget.interactionTransform;
	}

	public void StopFollowingTarget ()
	{
		playerNavMeshAgent.stoppingDistance = 0f;
		playerNavMeshAgent.updateRotation = true;

		target = null;
	}



	// void OnFocusChanged (Interactable newFocus)
	// {
	// 	if (newFocus != null)
	// 	{
	// 		agent.stoppingDistance = newFocus.radius*.8f;
	// 		agent.updateRotation = false;

	// 		target = newFocus.interactionTransform;
	// 	}
	// 	else
	// 	{
	// 		agent.stoppingDistance = 0f;
	// 		agent.updateRotation = true;
	// 		target = null;
	// 	}
	// }

	void Update ()
	{
		if (target != null)
		{
			// MoveToPoint (target.position);
			// FaceTarget ();

			playerNavMeshAgent.SetDestination(target.position);
			FaceTarget();

		}
	}

	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}


}