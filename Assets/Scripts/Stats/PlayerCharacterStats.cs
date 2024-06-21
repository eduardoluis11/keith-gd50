using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This file stores the Player's stats.

The file was going to be originally called PlayerStats.cs, but I decided to call it PlayerCharacterStats.cs to avoid confusion with the 
PlayerStats.cs file in the Editor folder, since it seems that newer versions of Unity already have a function called "PlayerStats".

Source of most of this script: This file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Stats/PlayerStats.cs

This file also contains code from this Brackeys tutorial:
https://youtu.be/e8GmfoaOB4Y?si=mQlTqYYUBnDYzBnV
*/

/*
	This component is derived from CharacterStats. It adds two things:
		- Gaining modifiers when equipping items
		- Restarting the game when dying
*/

public class PlayerCharacterStats : CharacterStats {

	// Use this for initialization
	public override void Start () {

		base.Start();
		// EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	// void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	// {
	// 	if (newItem != null) {
	// 		armor.AddModifier (newItem.armorModifier);
	// 		damage.AddModifier (newItem.damageModifier);
	// 	}

	// 	if (oldItem != null)
	// 	{
	// 		armor.RemoveModifier(oldItem.armorModifier);
	// 		damage.RemoveModifier(oldItem.armorModifier);
	// 	}

	// }



}