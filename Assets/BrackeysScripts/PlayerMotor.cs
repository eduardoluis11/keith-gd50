using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Script that will allow the Cube version of Fang to move in a point-and-click manner, that is, the player will move if to wherever the 
player clicks on the screen by using their mouse (source of most of this code: Brackeys from this tutorial: 
https://youtu.be/S2mK6KFdv0I?si=wCJUeCQSWAdYNRvz .) 
*/

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{

    Transform target; // Target to follow
    NavMeshAgent agent; // Reference to the NavMeshAgent

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
    }

    void Update () {
        if (target != null)
        {
            agent.SetDestination(target.position); // Move the player to the target
            FaceTarget(); 
   
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point); // Move the player to the point
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;

        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
