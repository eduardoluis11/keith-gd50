using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will handle the player's animations.

Source of most of this code: This video from Brackeys: https://www.youtube.com/watch?v=yhPRkihs-Yg
*/

public class PlayerAnimator : CharacterAnimator
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // If I add the "update", the medieval cartoon character won't have any walking nor sprinting animation.
}
