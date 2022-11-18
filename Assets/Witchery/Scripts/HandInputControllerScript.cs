using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandInputControllerScript : MonoBehaviour
{

    /* 
       Detta script h�mtar input v�rden fr�n unitys nya input system n�r det kommer till Grip och Trigger knapparna p� kontrollerna.
       Det v�rdet som l�ses ut kommer att anv�ndas f�r att bed�mma hur h�rt man trycker p� knappen f�r att sedan l�ta Blendtree sk�ta animationen.
    */

    // Skapar tv� nya input action references som g�r att vi kan koppla ihop trigger och grip actions med nya input systemet.
    [SerializeField]
    InputActionReference gripInput;

    [SerializeField]
    InputActionReference triggerInput;

    // Deklarerar en ny animator, eftersom vi ska anv�nda animatorn p� objekten som skripten ligger p�.
    Animator anim;

    private void Awake()
    {
        // H�r assignas animatorn till variabeln anim.
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // N�r gameobjektet blir aktiverat s� ska vi ligga och lyssa efter att n�gon trycker p� grip eller trigger knappen.
        gripInput.action.performed += GripPress;
        triggerInput.action.performed += TriggerPress;
    }

    // Dessa tv� funktioner l�ser av ett float v�rde om hur h�rt vi klickar p� knapparna och skickar sedan detta till animatorn
    // Animatorn anv�der sig av blendtree f�r att spela animationen.
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
        // N�r objektet blir disablat s� ska vi sluta lyssna p� knapptryckningarna.
        gripInput.action.performed -= GripPress;
        triggerInput.action.performed -= TriggerPress;
    }



}
