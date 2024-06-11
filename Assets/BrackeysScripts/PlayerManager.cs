using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
