using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartGame : MonoBehaviour
{

    public Flowchart flowchart;


    public void StartGamePressed()
    {
        flowchart.ExecuteBlock("Stage 1 Intro");
    }
}