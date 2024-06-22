using UnityEngine;

/* Contains all the stats for a character. 

Source of most of this code: This file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Stats/CharacterStats.cs

This file also contains code from this Brackeys tutorial:
https://youtu.be/e8GmfoaOB4Y?si=zhrGK3CN0_Xaabfn
*/

/* Another script for handling stats, such as Health and Attack points, but for the Player character.
 * 
 * Source of most of the code in this script: Brackeys from  https://www.youtube.com/watch?v=e8GmfoaOB4Y 
*/



/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour {

	// Health
	public int maxHealth = 100;
	public int currentHealth { get; private set; }

	public Stat damage;
	public Stat armor;

	public event System.Action<int, int> OnHealthChanged;

	// Set current health to max health
	// when starting the game.
	void Awake ()
	{
		currentHealth = maxHealth;
	}

	// Damage the character
	public void TakeDamage (int damage)
	{
		// Subtract the armor value
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		// Damage the character
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");

		if (OnHealthChanged != null)
		{
			OnHealthChanged(maxHealth, currentHealth);
		}

		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die ()
	{
		// Die in some way
		// This method is meant to be overwritten
		Debug.Log(transform.name + " died.");
	}

}

// public class CharacterStats : MonoBehaviour
// {

//     public int maxHealth = 100;
//     public int currentHealth { get; private set; }

//     public Stat damage;
//     public Stat armor;

// 	public event System.Action OnHealthReachedZero;

//     void Awake () {
//         currentHealth = maxHealth;
//     }

//     void Update () {
//         if (Input.GetKeyDown(KeyCode.T)) {
//             TakeDamage(10);
//         }
//     }

//     public void TakeDamage (int damage) {
//         damage -= armor.GetValue();
//         damage = Mathf.Clamp(damage, 0, int.MaxValue);

//         currentHealth -= damage;
//         Debug.Log(transform.name + " takes " + damage + " damage.");

//         if (currentHealth <= 0) {

//             // DEBUG message to confirm that this snippet exectures when the player dies
//             Debug.Log("The die() method should be called, but it's not working.");
//             Die();

// 			// 			if (OnHealthReachedZero != null) {
// 			// 	OnHealthReachedZero ();
// 			// }
//         }
//     }

//     public virtual void Die () {
//         // Die in some way
//         // This method is meant to be overwritten
//         Debug.Log(transform.name + " died.");
//     }
// }

// public class CharacterStats : MonoBehaviour {

// 	// public Stat maxHealth;			// Maximum amount of health

//     public int maxHealth = 100;	// Maximum amount of health

// 	public int currentHealth {get;protected set;}	// Current amount of health

// 	public Stat damage;
// 	public Stat armor;

// 	public event System.Action OnHealthReachedZero;

// 	// public virtual void Awake() {
//     public virtual void Awake() {
// 		// currentHealth = maxHealth.GetValue();
//         currentHealth = maxHealth;
// 	}

//     void Update() {
//         if (Input.GetKeyDown(KeyCode.T)) {
//             TakeDamage(10);
//         }
//     }

// 	// Start with max HP.
// 	public virtual void Start ()
// 	{
		
// 	}

// 	// Damage the character
// 	public void TakeDamage (int damage)
// 	{
// 		// Subtract the armor value - Make sure damage doesn't go below 0.
// 		damage -= armor.GetValue();
// 		damage = Mathf.Clamp(damage, 0, int.MaxValue);

// 		// Subtract damage from health
// 		currentHealth -= damage;
// 		Debug.Log(transform.name + " takes " + damage + " damage.");

// 		// If we hit 0. Die.
// 		if (currentHealth <= 0)
// 		{
// 			// if (OnHealthReachedZero != null) {
// 			// 	OnHealthReachedZero ();
// 			// }

// 			Die();
// 		}
// 	}

// 	public virtual void Die () {
//         // Die in some way
//         // This method is meant to be overwritten
//         Debug.Log(transform.name + " died.");
//     }

// 	// Heal the character.
// 	public void Heal (int amount)
// 	{
// 		currentHealth += amount;
// 		// currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
//         currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
// 	}





// }