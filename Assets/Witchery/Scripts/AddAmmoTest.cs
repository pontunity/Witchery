using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmoTest : MonoBehaviour
{
    public int ammo = 0;


    public void addAmmoWhenXPattern(string patternName)
    {
        if (patternName == "X")
        {
            Debug.Log("X was Drawn");
            ammo++;
        }

        else if (patternName == "P")
        {
            Debug.Log("P was Drawn");
            
        }
    }
}
