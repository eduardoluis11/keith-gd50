using UnityEngine;

/* Another script for handling stats, such as Health and Attack points, but for the Player character.
 * 
 * Source of most of the code in this script: Brackeys from  https://www.youtube.com/watch?v=e8GmfoaOB4Y 
*/

public class CharacterStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    void Awake () {
        currentHealth = maxHealth;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die () {
        // Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }
}
