using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This will exit the game after pressing Escape on the "Press Start "scene.
*/

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame.
    /* This detects if the player presses Escape in the "Press Start" scene every frame.

    If the player presses Escape, they will exit the game, and will go back to their desktop.
    */
    void Update()
    {
        // If the player presses Escape
        if (Input.GetKey(KeyCode.Escape))
        {
            // DEBUG: This will print "Escape pressed" in the console
            Debug.Log("You pressed Esc. The game will now exit.");

            // This exits the game
            Application.Quit();
        }
    }
}
