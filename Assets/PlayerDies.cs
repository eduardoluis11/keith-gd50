using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I need this in order to use the "SceneManager" class (source: Copilot on VS Code via "Quick Fixes")
using UnityEngine.SceneManagement;

/* Script for making the player Die and go to the Game Over scene. 

Some of the code on this script will be taken from the "DespawnOnHeight.cs" script from my "Dreadhalls" project.

For debugging purposes, I will make it so that, if I press “0”, I’ll go to the “Game over scene”.
*/

public class PlayerDies : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame.
    // This will make the player die and go to the Game Over scene.
    void Update()
    {

        // If the player presses "0", they will go to the "Game Over" scene. DEBUGGING PURPOSES. SOURCE: Copilot VS Code.
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            SceneManager.LoadScene("GameOver");
        }

        // This is the code from the "DespawnOnHeight.cs" script from my "Dreadhalls" project.
        //         // If the player falls below the height of -10.
        // // BUGGY: this didn't work.
        // //        if (characterController.transform.position.y < -10) {
        // // This detects the player if they fall below the height of -10 (source: Copilot)
        // if (gameObject.transform.position.y < -10) {

        //     // DEBUG: The player will be sent to the next level (I will later change this to a "Game Over" screen).
        //     SceneManager.LoadScene("GameOver");

        //     // DEBUG: this indicates that you fell through a hole
        //     Debug.Log("You fell through a hole. Game Over");
        // }
    }
}
