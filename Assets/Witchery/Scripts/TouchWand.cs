using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TouchWand : MonoBehaviour
{
    bool hasBeenTriggered = false;
    public Flowchart flowchart;

    // Start is called before the first frame
    // 
    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenTriggered == false)
        {
            flowchart.ExecuteBlock("ChangeScene");
        }

    }
}
