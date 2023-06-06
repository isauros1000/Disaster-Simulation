using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTracker : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float countdown = 0f;
    public float additionalTime = 60;
    private bool startedCountdown = false;
    private int fireCount = 0;
    public int fireScoreMultiplier = 1;
    public ScoreTracking scoreTrackingRef;

    // Start is called before the first frame update
    void Start()
    {
        // No text will who until we have started countdown
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the countdown every frame
        if(startedCountdown && countdown > 0) {
            text.text = "Time Left: " + (int)countdown;
            countdown -= Time.deltaTime;
        }
    }

    //Scripts can access this method to tell us the player is in range of a new fire
    public void PlayerInRange()
    {
        //Start the countdown and increase the number of fires the player currently has to put out
        startedCountdown = true;
        fireCount++;
        countdown += additionalTime;
    }

    // Fire script can access this method to notify us the fire has been extinguished
    public void extinguishedFire()
    {
        fireCount--;
        // If there's no more fires left and time was still left on the clock, increase the score 
        if (fireCount <= 0 && countdown > 0) {
            scoreTrackingRef.IncreaseScore((int)countdown * fireScoreMultiplier);
            Restart();
        }
    }

    // Used to restart the values and hide the text after we've put out all the fires
    void Restart()
    {
        text.text = "";
        countdown = 0;
        fireCount = 0;
        startedCountdown = false;
    }
}
