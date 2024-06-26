using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Base class for all stats: health, armor, damage etc. 

Source of most of this code:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Stats/Stat.cs

Source of part of this code:
https://youtu.be/e8GmfoaOB4Y?si=5on5nACJJzCGD4SZ
*/

/* Class used for all stats where we want to be able to add/remove modifiers */

[System.Serializable]
public class Stat {

	[SerializeField]

    //	private int baseValue;	// Starting value

    // I changed this variable's name
    private int baseStatValue;	// Starting value

	// List of modifiers that change the baseValue
	private List<int> modifiers = new List<int>();

	// Get the final value after applying modifiers
	public int GetValue ()
	{
		int finalValue = baseStatValue;
		modifiers.ForEach(x => finalValue += x);
		return finalValue;
	}

	// Add new modifier
	public void AddModifier (int modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);
	}

	// Remove a modifier
	public void RemoveModifier (int modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}

}

// [System.Serializable]
// public class Stat {

//     [SerializeField]
//     private int baseValue;	// Starting value
// 	// public int baseValue;	// Starting value

// 	// Keep a list of all the modifiers on this stat
// 	private List<int> modifiers = new List<int>();

// 	// Add all modifiers together and return the result
// 	public int GetValue ()
// 	{
// 		int finalValue = baseValue;
// 		modifiers.ForEach(x => finalValue += x);
// 		return finalValue;
// 	}

// 	// Add a new modifier to the list
// 	public void AddModifier (int modifier)
// 	{
// 		if (modifier != 0)
// 			modifiers.Add(modifier);
// 	}

// 	// Remove a modifier from the list
// 	public void RemoveModifier (int modifier)
// 	{
// 		if (modifier != 0)
// 			modifiers.Remove(modifier);
// 	}

// }