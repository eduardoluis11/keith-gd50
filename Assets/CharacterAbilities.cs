using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles Fang's Physical Skills / Attacks and Spells / Magic (source: ChatGPT 4.0).

*/

public class CharacterAbilities : MonoBehaviour
{

	public float attackPower = 10f;
	public float magicPower = 20f;
	public float health = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Trigger physical attack (by pressing F)
    	{
        	PerformAttack();
    	}
    	if (Input.GetKeyDown(KeyCode.G)) // Trigger magical ability (by pressing G)
    	{
        	CastSpell();
    	}
    }

    /* This allows me to Attack / use Physical Skills */
    void PerformAttack()
	{
    	Debug.Log("Performing physical attack with power " + attackPower);
    	// Add logic for physical attack animations and effects
	}

    /* This allows me to use Spells / Magic */
	void CastSpell()
	{
    	Debug.Log("Casting spell with power " + magicPower);
    	// Add logic for spell animations and magical effects
	}

}
