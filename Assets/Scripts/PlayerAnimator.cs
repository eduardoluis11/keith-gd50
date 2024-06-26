using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will handle the player's animations.

Source of most of this code: This video from Brackeys: https://www.youtube.com/watch?v=yhPRkihs-Yg



Given the structure of WeaponAnimations which contains an array of AnimationClip[] named clips, if you want to transform this into a variable that 
counts the number of items (i.e., the number of AnimationClip objects within clips), you would typically access the Length property of the array. 
However, since your goal seems to be to count the number of WeaponAnimations instances (which I assume are collected in an array or list themselves 
to represent each weapon's animations), you would count the number of WeaponAnimations instances instead (source: VS Code's Copilot).

Assuming you have a collection (like an array or list) of WeaponAnimations, here's how you can set the numberOfWeapons variable:

If you have an array of WeaponAnimations, you use the Length property.
If you have a list of WeaponAnimations, you use the Count property.
Here's an example for both cases:

If you have an array of WeaponAnimations:
If you have a List of WeaponAnimations:
This numberOfWeapons variable can then be used to define the size of your AnimationClip[][] array if you're planning to organize your animations 
in a two-dimensional array where each row represents a weapon and each column represents a different animation for that weapon (source: VS Code's Copilot).

Actually, I don't know the exact number of items that I will be storing into the weaponAnimationsArrray. I modified my code  this so that I don't have to type the "numberOfWeapons" variable.
*/

public class PlayerAnimator : CharacterAnimator
{

    public WeaponAnimations[] weaponAnimations;
    // This will store the different attack animations
    // List<List<AnimationClip>> weaponAnimationsList = new List<List<AnimationClip>>();
    List<List<AnimationClip>> weaponAnimationsList;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // I added this list using Copilot. I didn't copy and paste this from the Brackeys' tutorial.
        List<List<AnimationClip>> weaponAnimationsList = new List<List<AnimationClip>>();
        foreach (WeaponAnimations a in weaponAnimations)
        {
            weaponAnimationsList.Add(new List<AnimationClip>(a.clips));
        }


        // AnimationClip[][] weaponAnimationsArray = new AnimationClip[numberOfWeapons][];
        // weaponAnimationsDict = new Dictionary<AnimationClip[]>();
        // Dictionary<string, AnimationClip[]> weaponAnimationsDict = new Dictionary<string, AnimationClip[]>();
    }

    [System.Serializable]
    public struct WeaponAnimations
    {
        
        public AnimationClip[] clips;
    }

    // If I add the "update", the medieval cartoon character won't have any walking nor sprinting animation.
}
