using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will let the Boss / Enemy to hurt the Player, so that Fang takes damage when he touches the Boss. 

In this script, `damage` is the amount of HP the player will lose when the enemy collides with them. The 
`OnCollisionEnter` method is a Unity callback that is invoked when this object starts colliding with another object. 
Inside this method, we first check if the object we collided with is the player (by checking if its tag is "Player"). 
If it is, we get the `PlayerStats` component from the player object and reduce the player's HP by the enemy's damage
(source: Copilot).

To use this script, you would attach it to the enemy's capsule. Also, make sure that your player character's game 
object has the tag "Player" and the `PlayerStats` script attached (source: Copilot).

*/

public class EnemyDamage : MonoBehaviour
{

    // This is the PlayerStats script that will be used to access the Player's HP (source: https://www.youtube.com/watch?v=_1Oou4459Us)
    public PlayerStats playerStats;

    // This is the damage that the Boss will do to the Player (source: Copilot)
    public int damage = 10;

    // This detects if the Boss makes collision with the Player (source: Copilot)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // I optimized my code that makes the Boss damage the player (source: https://www.youtube.com/watch?v=_1Oou4459Us)

            // If the Boss touches the Player, the Player will take damage
            playerStats.HP -= damage;

            // DEBUG: This will print "Player took (number of points) damage" in the console
            Debug.Log("Player took " + damage + " damage");




            // PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            // if (playerStats != null)
            // {
            //     // If the Boss touches the Player, the Player will take damage
            //     playerStats.HP -= damage;

            //     // DEBUG: This will print "Player took (number of points) damage" in the console
            //     Debug.Log("Player took " + damage + " damage");

            // }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


