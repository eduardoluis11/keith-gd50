using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script contains everything about the Boss (the enemy.)

Source of most of this code: This file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/RPG%20Project/Assets/Scripts/Enemy.cs

I also took some snippets from this video:
https://www.youtube.com/watch?v=xppompv1DBg
*/

/* This script will handle part of the enemy's behavior.

Source of most of this code: Brackeys, Episode 10, from https://youtu.be/xppompv1DBg?si=3pQUWe7HilQ3vLNF

*/


/* Handles interaction with the Enemy */

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

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
	}

}

// [RequireComponent(typeof(CharacterStats))]
// public class Enemy : Interactable
// {

//     PlayerManager playerManager;
//     CharacterStats myStats;

//     void Start ()
//     {
//         playerManager = PlayerManager.instance;
//         myStats = GetComponent<CharacterStats>();

//     }

//     public override void Interact()
//     {
//         base.Interact();
//         CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
//         if (playerCombat != null)
//         {
//             playerCombat.Attack(myStats);
// 			// playerCombat.Attack();
//         }

//         // Attack the enemy
//     }
// }

// [RequireComponent(typeof(CharacterStats))]
// public class Enemy : Interactable {

// 	PlayerManager playerManager;
// 	CharacterStats myStats;

// 	void Start ()
// 	{
// 		playerManager = PlayerManager.instance;
// 		myStats = GetComponent<CharacterStats>();
// 	}

// 	public override void Interact()
// 	{
// 		base.Interact();
// 		CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
// 		if (playerCombat != null)
// 		{
// 			playerCombat.Attack(myStats);
// 		}
// 	}

// }