using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System;

public class MovementRecognizer : MonoBehaviour
{

    public Transform movementSource;
    private List<Vector3> positionsList = new List<Vector3>();

    public float newPositionThresholdDistance = 0.05f;
    public GameObject debugCubePrefab;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {


    }
    void Update()
    {
        UpdateMovement();
    }

    public void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);

        if (debugCubePrefab)
        {
            Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3) ;
        }

    }
    // Update is called once per frame

    public void EndMovement()
    {
        Debug.Log("End Movement");
    }

    public void UpdateMovement()
    {
        Debug.Log("UpdateMovement");
        Vector3 lastpostion = lastpostion = positionsList[positionsList.Count - 1];

        if(Vector3.Distance(movementSource.position,lastpostion) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);
            if (debugCubePrefab)
            {
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
            }   

        }
        


    }
}
