using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will handle the enemy's stats.

Source of most of this code: Brackeys from https://youtu.be/xppompv1DBg?si=BXFLKmNbRF49cmwz

*/

public class EnemyStats : CharacterStats
{

    public override void Die()
    {
        base.Die();

        // Add ragdoll effect
        Destroy(gameObject);
    }

    
}
