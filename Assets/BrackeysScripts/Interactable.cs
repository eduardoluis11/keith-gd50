using UnityEngine;

/* This script will allow the player to interact with objects in the game, WHICH includes enemies
(such as the boss.) Source of most of this code: Brackey's tutorial from: 
https://youtu.be/9tePzyL6dgc?si=i6dSdIY29xrdMJVN 
*/

public class Interactable : MonoBehaviour
{

    public float radius = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
