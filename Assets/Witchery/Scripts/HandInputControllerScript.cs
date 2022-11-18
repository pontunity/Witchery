using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandInputControllerScript : MonoBehaviour
{

    /* 
       Detta script hämtar input värden från unitys nya input system när det kommer till Grip och Trigger knapparna på kontrollerna.
       Det värdet som läses ut kommer att användas för att bedömma hur hårt man trycker på knappen för att sedan låta Blendtree sköta animationen.
    */

    // Skapar två nya input action references som gör att vi kan koppla ihop trigger och grip actions med nya input systemet.
    [SerializeField]
    InputActionReference gripInput;

    [SerializeField]
    InputActionReference triggerInput;

    // Deklarerar en ny animator, eftersom vi ska använda animatorn på objekten som skripten ligger på.
    Animator anim;

    private void Awake()
    {
        // Här assignas animatorn till variabeln anim.
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // När gameobjektet blir aktiverat så ska vi ligga och lyssa efter att någon trycker på grip eller trigger knappen.
        gripInput.action.performed += GripPress;
        triggerInput.action.performed += TriggerPress;
    }

    // Dessa två funktioner läser av ett float värde om hur hårt vi klickar på knapparna och skickar sedan detta till animatorn
    // Animatorn anväder sig av blendtree för att spela animationen.
    private void TriggerPress(InputAction.CallbackContext obj)
    {
        anim.SetFloat("Trigger",obj.ReadValue<float>());
    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        anim.SetFloat("Grip", obj.ReadValue<float>());
    }

    private void OnDisable()
    {
        // När objektet blir disablat så ska vi sluta lyssna på knapptryckningarna.
        gripInput.action.performed -= GripPress;
        triggerInput.action.performed -= TriggerPress;
    }



}
