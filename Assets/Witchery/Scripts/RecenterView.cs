using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecenterView : MonoBehaviour
{
    public GameObject headSetPos;
   // public Slider heightSlider;


    public void ResetHeadsetPosition()
    {
        headSetPos.transform.position = new Vector3(0, 0, 0);
        var rotation = headSetPos.transform.eulerAngles;
        rotation.x = 0;
        rotation.z = 0.161f;
        rotation.y = 1;
        headSetPos.transform.eulerAngles = rotation;
       // heightSlider.value = 1.5f;
    }

}
