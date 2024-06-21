using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/* Enemy script to make the Boss hurt the player and follow him around.

Most of the code from this script comes from this tutorial from Brackeys:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Controllers/EnemyController.cs

Additionally, I also got some snippets from this video from Brackeys:
https://youtu.be/xppompv1DBg?si=CSNgYD33oE0m_LPu
*/


// [RequireComponent(typeof(CharacterCombat))]
public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;
	// CharacterCombat combatManager;

	void Start()
	{
		target = PlayerManager.instance.player.transform;
		// target = Player.instance.transform;
		agent = GetComponent<NavMeshAgent>();
		// combatManager = GetComponent<CharacterCombat>();
	}

	void Update ()
	{
		// Get the distance to the player
		float distance = Vector3.Distance(target.position, transform.position);

		// If inside the radius
		if (distance <= lookRadius)
		{
			// Move towards the player
			agent.SetDestination(target.position);
			if (distance <= agent.stoppingDistance)
			{
				// Attack
				// combatManager.Attack(Player.instance.playerStats);
				FaceTarget();
			}
		}
	}

	// Point towards the player
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

}