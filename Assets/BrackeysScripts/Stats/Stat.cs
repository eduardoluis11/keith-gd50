using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to handle Stats (such as Helth and Attack points).

Source of most of the code in this script: https://www.youtube.com/watch?v=e8GmfoaOB4Y
*/

[System.Serializable]
public class Stat 
{

    [SerializeField]
    private int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
        // return baseValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }

}
