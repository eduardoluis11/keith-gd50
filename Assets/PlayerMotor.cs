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

    NavMeshAgent agent; // Reference to the NavMeshAgent

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point); // Move the player to the point
    }
}
