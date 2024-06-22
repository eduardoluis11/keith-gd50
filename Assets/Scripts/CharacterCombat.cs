using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will handle the game's combat.

Most of this code comes from this file from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/RPG%20Project/Assets/Scripts/CharacterCombat.cs

I also took some code from this file from the same tutorial:
https://www.youtube.com/watch?v=FhAdkLC-mSg 
*/

/* Script for handling combat.

Source of most of this code: Episode 11 of this tutorial from Brackeys: https://youtu.be/FhAdkLC-mSg?si=6gtY_Thz0OCcBrTg
*/


/* Script for handling combat.

Source of most of this code: Episode 11 of this tutorial from Brackeys: https://youtu.be/FhAdkLC-mSg?si=6gtY_Thz0OCcBrTg
*/

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

	public float attackSpeed = 1f;
    private float attackCooldown = 0f;

	CharacterStats myStats;

	void Start ()
	{
		myStats = GetComponent<CharacterStats>();
	}

	void Update ()
	{
		attackCooldown -= Time.deltaTime;
	}

	public void Attack (CharacterStats targetStats)
	{
		if (attackCooldown <= 0f)
		{
			targetStats.TakeDamage(myStats.damage.GetValue());
			attackCooldown = 1f / attackSpeed;
		}
		
	}



    // public float attackDelay = .6f;

    // public event System.Action OnAttack;
    
    // CharacterStats myStats;

    // void Start ()
    // {
    //     myStats = GetComponent<CharacterStats>();
    // }

    // void Update ()
    // {
    //     attackCooldown -= Time.deltaTime;
    // }

    // public void Attack (CharacterStats targetStats)
    // {
    //     if (attackCooldown <= 0f)
    //     {
            
    //         StartCoroutine(DoDamage(targetStats, attackDelay));

    //         if (OnAttack != null)
    //             OnAttack();

    //         attackCooldown = 1f / attackSpeed;
    //     }
    // }

    // IEnumerator DoDamage(CharacterStats stats, float delay)
    // {
    //     yield return new WaitForSeconds(delay);

    //     stats.TakeDamage(myStats.damage.GetValue());
    // }

}

// [RequireComponent(typeof(CharacterStats))]
// public class CharacterCombat : MonoBehaviour
// {

//     public float attackSpeed = 1f;
//     private float attackCooldown = 0f;

//     public float attackDelay = .6f;

//     public event System.Action OnAttack;
    
//     CharacterStats myStats;

//     void Start ()
//     {
//         myStats = GetComponent<CharacterStats>();
//     }

//     void Update ()
//     {
//         attackCooldown -= Time.deltaTime;
//     }

//     public void Attack (CharacterStats targetStats)
//     {
//         if (attackCooldown <= 0f)
//         {
            
//             StartCoroutine(DoDamage(targetStats, attackDelay));

//             if (OnAttack != null)
//                 OnAttack();

//             attackCooldown = 1f / attackSpeed;
//         }
//     }

//     IEnumerator DoDamage(CharacterStats stats, float delay)
//     {
//         yield return new WaitForSeconds(delay);

//         stats.TakeDamage(myStats.damage.GetValue());
//     }

// }