using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This handles the boss' stats (the enemy's stats.)

Source of most of this code: This file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/RPG%20Project/Assets/Scripts/Stats/EnemyStats.cs

I also took some snippets from this video:
https://www.youtube.com/watch?v=xppompv1DBg
*/


/* Keeps track of enemy stats, loosing health and dying. */

public class EnemyStats : CharacterStats {

    // I changed this function's name
    //    	public override void Die()
	public override void Defeated()
	{
        //		base.Die();
        base.Defeated();

		// Add ragdoll effect / death animation

		Destroy(gameObject);
	}

}

// public class EnemyStats : CharacterStats {

// 	public override void Die()
// 	{
// 		base.Die();

// 		// Add ragdoll effect / death animation

// 		Destroy(gameObject);
// 	}

// }