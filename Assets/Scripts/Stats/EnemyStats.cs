using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This will allow me to change scenes (source: Copilot on VS Code via "Quick Fixes")
using UnityEngine.SceneManagement;

/* This handles the boss' stats (the enemy's stats.)

Source of most of this code: This file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/RPG%20Project/Assets/Scripts/Stats/EnemyStats.cs

I also took some snippets from this video:
https://www.youtube.com/watch?v=xppompv1DBg
*/


/* This keeps track of enemy stats, if the enemy losed health, and if the enemy dies. 

If the enemy dies, he will disappear.

I will also make it so that, if you kill the enemy, you will be transported to a "Victory" scene.
*/

public class EnemyStats : CharacterStats {

    // I changed this function's name
    //    	public override void Die()
	public override void Defeated()
	{
        //		base.Die();
        base.Defeated();

		// Add ragdoll effect / death animation

		// This makes the enemy's 3D model to disappear when he's defeated.
		Destroy(gameObject);

		// This transports the player to the "Victory" scene when the enemy is defeated.
		SceneManager.LoadScene("Victory");

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