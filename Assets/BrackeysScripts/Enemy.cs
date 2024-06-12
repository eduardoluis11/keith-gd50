using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will handle part of the enemy's behavior.

Source of most of this code: Brackeys, Episode 10, from https://youtu.be/xppompv1DBg?si=3pQUWe7HilQ3vLNF

*/

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{

    PlayerManager playerManager;
    CharacterStats myStats;

    void Start ()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();

    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }

        // Attack the enemy
    }
}
