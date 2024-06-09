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

    public int GetValue()
    {
        return baseValue;
    }

}
