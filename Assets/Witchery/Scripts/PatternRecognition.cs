using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PDollarGestureRecognizer;


public class PatternRecognition : MonoBehaviour
{

    // A new input action reference variable called open menu is created
    [SerializeField]
    InputActionReference openMenu;
    public Transform movementSource;
    private List<Vector3> positionsList = new List<Vector3>();
    

    public float newPositionThresholdDistance = 0.05f;
    public GameObject debugCubePrefab;
    public bool creationMode = false;
    public string newGestureName;

    private List<Gesture> trainingSet = new List<Gesture>();

    public bool isMoving = false;
    public float inputThreshold = 0.1f;

    // A bool that will open the menu, it is set to false at the start.
    public bool openmenu = false;


    private void OnEnable()
    {
        // when the gameobject containing the script is enabled it will subscribe  to the openMenu callback.
        // Then it will wait for the player to click on the menubutton on the controller.
        openMenu.action.performed += StartMovement;
    }

    private void OnDisable()
    {
        // when the gameobject is disabled it will, stop subscribing to the openMenu callback.
        
        openMenu.action.performed -= StartMovement;
    }

    private void StartMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
            isMoving = true;
        if (context.canceled)
            isMoving = false;
        {
            Debug.Log("Button Pressed");

        }

    }
    private void Update()
    {


        if (isMoving == true)
        {
            Debug.Log("Start Movement");
            positionsList.Clear();
            positionsList.Add(movementSource.position);

            if (debugCubePrefab)
            {
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
            }
        }

        if (isMoving == false)
        {
            Debug.Log("Released Button");
        }
    }
    void EndMovement()
        {
            Debug.Log("End Movement");
            isMoving = false;

            // Create gesture from the position list.
            Point[] pointArray = new Point[positionsList.Count];

            for (int i = 0; i < positionsList.Count; i++)
            {
                Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
                pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);


            }
            Gesture newGesture = new Gesture(pointArray);

            // Add new Gesture to training set.
            if (creationMode)
            {
                newGesture.Name = newGestureName;
                trainingSet.Add(newGesture);

            }

            else
            {
                Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
                Debug.Log(result.GestureClass + result.Score);
            }

        }


        void UpdateMovement()
        {
            Debug.Log("UpdateMovement");
            Vector3 lastpostion = lastpostion = positionsList[positionsList.Count - 1];

            if (Vector3.Distance(movementSource.position, lastpostion) > newPositionThresholdDistance)
            {
                positionsList.Add(movementSource.position);
                if (debugCubePrefab)
                {
                    Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
                }

            }
        }

    

}