using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OpenBook : MonoBehaviour
{
    bool hasBeenTriggered = false;
    public Flowchart flowchart;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenTriggered == false)
        {
            flowchart.ExecuteBlock("Stage 1 Page 1");
        }

    }
}
