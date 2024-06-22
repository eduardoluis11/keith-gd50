using UnityEngine;
using UnityEngine.AI;
using System.Collections;


/* Enemy script to make the Boss hurt the player and follow him around.

Most of the code from this script comes from this tutorial from Brackeys:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Controllers/EnemyController.cs

Additionally, I also got some snippets from this video from Brackeys:
https://youtu.be/xppompv1DBg?si=CSNgYD33oE0m_LPu
*/

/* This script will handle the enemy's behavior. 

Source of most of this code: Brackeys from https://youtu.be/xppompv1DBg?si=1nNpE-RKdg8whd45

This will let the enemy hurt the player when they get close enough (source: 
https://youtu.be/FhAdkLC-mSg?si=Z3h7cQ4XADFlGYhm .)
*/

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance) {

                CharacterStats targetStats = target.GetComponent<CharacterStats>();

                if (targetStats != null) {
                    combat.Attack(targetStats);
                }

                // Attack the target
                FaceTarget();
            }
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}