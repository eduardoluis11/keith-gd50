using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This will let me use the SceneManager class to load the "Game Over" scene (source: VS Code's Copilot)
using UnityEngine.SceneManagement;


/* This script will store the Player Character's stats (such as HP, and Attack and Defense points.)

This is more or less like the "init()" function of the Player Character.

To make the Player get a Game Over if the Player loses all of their HP, you will need to check if the player's HP has
dropped to 0 in the Update method, and if so, load the "Game Over" scene.  You will need to use
SceneManager.LoadScene("GameOver"); to load the "Game Over" scene. Make sure you have added the "GameOver" scene to
your build settings in Unity (source: Copilot).

The Update method checks every frame if the player's HP has dropped to 0 or less. If it has, it loads the "Game Over"
scene (source: Copilot).
 */

public class PlayerStats : MonoBehaviour
{

    // These are the stats of the Player Character (source: Pycharm's Copilot)
    public int HP = 100;    // The Player Character's Health Points
    public int attack = 10; // The Player Character's Attack Points
    public int defense = 5; // The Player Character's Defense Points


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame.
    // This checks every frame if the player's HP has dropped to 0 or less. If it has, it loads the "Game Over" scene
    void Update()
    {
        // If the player's HP drops to 0 or less
        if (HP <= 0)
        {
            // Load the "Game Over" scene
            SceneManager.LoadScene("GameOver");
        }
    }
}
