/* Script that will print the current HP for the Player as UI text onscreen.

Source of most of this code: I used the MazeLevelText.cs script from my submission for the Dreadhalls assignment from Harvard' GD50 course:
https://github.com/eduardoluis11/dreadhalls/blob/main/Assets/MazeLevelText.cs .

I also used my own code from my submission for the Helicopter Game assignment from GD50:
https://github.com/eduardoluis11/helicopter-gd50/blob/main/Assets/Resources/Scripts/CoinText.cs .
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; // Add this namespace to use TextMeshPro components (source: Copilot)


// [RequireComponent(typeof(Text))]

/* 

I’ll have to make a Canvas Game Object, just like in the Title and the Game Over scene. Then’ I’ll have to add
some text like “Fang”. Then, I’ll have to attach this script to that Canvas Game Object.

Actually, never mind: I don’t have to write anything on the “Text:” option of the Unity editor: the text there gets
automatically typed / written. Probably the “text” property automatically types what should be
written in there so that it writes the correct number of HP points remaining for the player character.

To manipulate the text from the UI Text game object in Unity using the selected snippet from your script, and considering the error message you 
received, you need to modify the script to use the TextMeshProUGUI component instead of the Text component. This is because your project is using 
TextMeshPro for UI text rendering, which is more flexible and feature-rich compared to the older Text component (source: Copilot).

Workspace
To manipulate the text from the UI Text game object in Unity using the selected snippet from your script, and considering the error message you 
received, you need to modify the script to use the TextMeshProUGUI component instead of the Text component. This is because your project is using 
TextMeshPro for UI text rendering, which is more flexible and feature-rich compared to the older Text component.

Here's how you can refactor the selected code snippet to work with TextMeshPro:

This refactored code snippet does the following:

Imports the TMPro namespace which is required to work with TextMeshPro components.
Changes the type of the text variable to TextMeshProUGUI, which is the correct type for manipulating TextMeshPro UI text.
Initializes the textMeshProUGUI variable in the Start method by getting the TextMeshProUGUI component attached to the same GameObject.
Updates the Update method to set the text of the textMeshProUGUI component. You'll need to adjust the logic here to match what text you want to 
display based on your game's logic.
Make sure to attach this script to a GameObject that has a TextMeshProUGUI component. If you follow these steps, you should be able to manipulate 
the text without encountering the error message you mentioned (source: Copilot).

To display the current and maximum health points of the player in the UI, you need to access the `currentHealth` and `maxHealth` variables from the 
`CharacterStats` script (source: Pycharm's Copilot).

First, you need to get a reference to the `PlayerCharacterStats` script from the `HealthUIText` script. You can do this by adding a public variable 
of type `PlayerCharacterStats` in the `HealthUIText` script. Then, in the Unity editor, you can drag the player object (which should have the 
`PlayerCharacterStats` script attached) to this variable to set the reference.

Once you have the reference, you can access the `currentHealth` and `maxHealth` variables and display them in the UI text. Here's how you can modify 
the `HealthUIText` script.

In the Unity editor, make sure to drag the player object to the `playerStats` variable in the `HealthUIText` script to set the reference 
(source: Pycharm's Copilot).
*/
public class HealthUIText : MonoBehaviour {

	// private Text text;

    public PlayerCharacterStats playerStats; // Reference to the PlayerCharacterStats script (Source: Copilot)
    private TextMeshProUGUI textMeshProUGUI; // Change type to TextMeshProUGUI (Source: Copilot)


	// Use this for initialization
	void Start () {
		// text = GetComponent<Text>();

        textMeshProUGUI = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component (Source: Copilot)

	}

	// Update is called once per frame
	void Update () {

        // Example of setting text, adjust according to your actual game logic (Source: Copilot).
        // Display the current and maximum health points in the UI text (source: Copilot).
        // Update to use textMeshProUGUI.
        textMeshProUGUI.text = "Fang: " + playerStats.currentHealth + "/" + playerStats.maxHealth;


		// text.text = "Current Level: " + GrabPickups.currentLevel;
        // text.text = "Fang: ";
	}
}