using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

/* Another script for handling stats, such as Health and Attack points, but for the Player character.
 * 
 * Source of most of the code in this script: Brackeys from  https://www.youtube.com/watch?v=e8GmfoaOB4Y .
 *
 * I will most likely not use this script in my game, since I won't use any equipment for the player character.
*/

public class PlayerStatsBrackeys : CharacterStats
{

    // // Start is called before the first frame update
    // void Start()
    // {
    //     EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public override void Die()
    {

        // DEbug message to confirm that this function is being called when the player dies (source: VS Code from Copilot).
        Debug.Log("Die method called");

        base.Die();
        // Kill the player
        PlayerManager.instance.KillPlayer();
    }
}
