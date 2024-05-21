using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/* This script will make the Boss (the enemy) follow the player.

Most of the code on this script is similar to the code from this tutorial from James Waghmare: 
https://www.youtube.com/watch?v=krKavfBuEQg .
*/

public class BossFollow : MonoBehaviour {

    // I will need to put the Player's Game Object as the target (source: https://www.youtube.com/watch?v=krKavfBuEQg)
    public Transform target;

    // The speed of the boss (source: https://www.youtube.com/watch?v=krKavfBuEQg)
    public float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // This makes the boss follow the player (source: https://www.youtube.com/watch?v=krKavfBuEQg)
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

