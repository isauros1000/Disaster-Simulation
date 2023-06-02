using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InRange : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI text;
    public float countdown = 60f;
    private bool startedCountdown = false;
    void Start()
    {

    }
    void Update()
    {
        // Update the countdown every frame
        if(startedCountdown) {
            countdown -= Time.deltaTime;
            text.text = "Time Left: " + (int)countdown;
        }
    }

    void OnTriggerEnter(Collider colliderObj)
    {
        // When the player is in range, start and show the countdown once
        if(!startedCountdown && colliderObj.CompareTag("Player")) {
            text.gameObject.SetActive(true);
            text.text = "Time Left: " + countdown;
            startedCountdown = true;
        }
    }

    void OnTriggerStay(Collider colliderObj)
    {
        // When player is within range, show button
        if (colliderObj.CompareTag("Player")) {
            myButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider colliderObj)
    {
        // When player is out of range, hide button
        if (colliderObj.CompareTag("Player")) {
            myButton.gameObject.SetActive(false);
        }
    }
}
