using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* This will load the "Main" scene after pressing Enter / Submit on the "Press Start "scene.

From the Dreadhalls homework, I could look up how to make it so that, if you press Enter in the Press Start screen, you
would be sent into the main (the actual gameplay) scene.

Source of most of this code: My own submission for the "Dreadhalls" project:
https://github.com/eduardoluis11/dreadhalls/blob/main/Assets/LoadSceneOnInput.cs
*/

public class LoadSceneWhenPressingEnter : MonoBehaviour {

    // This declares the function (initializes it)
    void Start () {

	}

    // This detects if the player presses Enter / Submit in the "Press Start" scene every frame (source:
    // https://github.com/eduardoluis11/dreadhalls/blob/main/Assets/LoadSceneOnInput.cs)
    void Update () {
		if (Input.GetAxis("Submit") == 1) {

            // I MIGHT USE THIS LATER. This could be used to return the player from the Game Over scene to the Press
            // Start scene. This detects the current scene.
            string currentScene = SceneManager.GetActiveScene().name;

            // If the Player is in the Game Over scene
			if (currentScene == "GameOver") {

//				// This should find the file with the whispers in the game, then, it will insert it into this variable
//				// (source: Copilot from VS Code)
//				GameObject WhisperSource = GameObject.Find("WhisperSource");
//
//				// This should stop the whispers from playing and eliminate it before going to the Title scene
//				Destroy(WhisperSource);
//
//                // This resets the level back to 0 if the player dies, so that they start once again from level 0
//                // (source: my own code from my submission for GD50's Helicopter Game assignment.)
//                GrabPickups.currentLevel = 0;
//			    // currentLevel = 0;

				// This sends the player back to the "Press Start" scene
				SceneManager.LoadScene("Title");

            // If the Player is in the Press Start scene
			} else if (currentScene == "Title") {

                // This sends the player to the "Main" Scene (where the actual gameplay takes place)
				SceneManager.LoadScene("Main");
			}

		}

	}   // End of the "Update" function

}