using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this namespace to use TextMeshPro components (source: Copilot)
using UnityEngine.UI;

/* Script that will print the current HP, as well as the max HP at full health, for the Enemy as UI text onscreen. 

*/


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
public class BossHealthUIText : MonoBehaviour
{

    public EnemyStats enemyStats; // Reference to the EnemyStats script (Source: Copilot)
    private TextMeshProUGUI textMeshProUGUI; // Change type to TextMeshProUGUI (Source: Copilot)

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component (Source: Copilot)
    }

    // Update is called once per frame
    void Update()
    {
        // Adjust text according to your actual game logic (Source: Copilot).
        // Display the current and maximum health points for the Enemy in the UI text (source: Copilot).
        // Update to use textMeshProUGUI.
        textMeshProUGUI.text = "Imanus: " + enemyStats.currentHealth + "/" + enemyStats.maxHealth;
    }
}



