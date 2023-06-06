using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonReaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject waterhosePS;
    public FireExtinguisher fireExtinguisherRef;
    bool isPressed = false;

    public void Update()
    {
        // Continuously extinguish the fire while button is pressed
        if (isPressed)
        {
            fireExtinguisherRef.Extinguish();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        // Start the particle system when button gets pressed
        isPressed = true;
        fireExtinguisherRef.ShowUp();
    }
    public void OnPointerUp(PointerEventData data)
    {
        // Stop the particle system when button is released
        isPressed = false;
        fireExtinguisherRef.StopPlaying();
    }
    
}
