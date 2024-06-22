using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This will be used alongside the EquipmentManager.cs, but I will use it so that the enemy can follow the player.

Source of most of this code: This file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/RPG%20Project/Assets/Scripts/PlayerManager.cs

Additionally, I also took some code from this video:
https://www.youtube.com/watch?v=xppompv1DBg
*/

/* This script will handle some of the player's behavior.

Source of most of this code: Brackeys from https://youtu.be/xppompv1DBg?si=3kwCGkXAiFa5vT0I

*/

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instance;

    void Awake() {
        instance = this;
    }

    #endregion

    public GameObject player;

    public void KillPlayer() {
        // Debug message to confirm that this function is being called, so that the scene could be reloaded
        // (source: VS Code from Copilot).
        Debug.Log("Reloading Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}