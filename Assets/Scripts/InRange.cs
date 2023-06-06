using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InRange : MonoBehaviour
{
    // public Button myButton;
    public CountdownTracker countdownTrackerRef;
    private bool alreadyInRange = false;
    
    void Start()
    {

    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider colliderObj)
    {
        // When the player is in range of THIS fire, send a message to start counter
        // and increase the number of fires they have to keep track of. Only
        // send message once.
        if(colliderObj.CompareTag("Player")) {
            if(!alreadyInRange) {
                countdownTrackerRef.PlayerInRange();
                alreadyInRange = true;
            }
        }
    }

    // void OnTriggerStay(Collider colliderObj)
    // {
    //     // When player is within range, show button
    //     if (colliderObj.CompareTag("Player")) {
    //         myButton.gameObject.SetActive(true);
    //     }
    // }

    // void OnTriggerExit(Collider colliderObj)
    // {
    //     // When player is out of range, hide button
    //     if (colliderObj.CompareTag("Player")) {
    //         myButton.gameObject.SetActive(false);
    //     }
    // }
}
