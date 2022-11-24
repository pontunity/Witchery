using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OpenBook : MonoBehaviour
{
    bool hasBeenTriggered = false;
    public Flowchart flowchart;

    // Start is called before the first frame update
    public void OpenTheBook()
    {
        if (hasBeenTriggered == false)
        {
            flowchart.ExecuteBlock("Stage 1 Page 1");
            hasBeenTriggered = true;
            Debug.Log("Open BOOK!");
        }

    }
}
