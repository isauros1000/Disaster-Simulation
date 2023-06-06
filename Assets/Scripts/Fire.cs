using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Range(0f,1f)]
    public float currIntensity = 1.0f;
    public float[] startingIntensities = new float[0];
    private float timeLastWatered = 0;
    public float regenerationTimeDelay = 2.5f;
    public float regenerationRate = 0.1f;
    private bool currentlyLit = true;
    private bool extinguishedMessageSent = false;
    public CountdownTracker countdownTrackerRef;

    public ParticleSystem[] fireParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the starting intensities for all the particle systems
        startingIntensities = new float[fireParticleSystem.Length];
        for (int i = 0; i < fireParticleSystem.Length; i++) {
            startingIntensities[i] = fireParticleSystem[i].emission.rateOverTime.constant;
        }
    }

    void Update()
    {
        // Increase the current intensity if has not been watered for more than regenerationTimeDelay seconds
        // and the fire is currently lit
        if (currentlyLit && Time.time - timeLastWatered >= regenerationTimeDelay && currIntensity < 1.0f) {
            currIntensity += regenerationRate * Time.deltaTime;
            // Update the current intensity
            UpdateIntensities();
        }
        
    }
    public bool TryExtinguish(float amount)
    {
        // Update timeLastWatered since we're watering rn
        timeLastWatered = Time.time;
        // Decrease the current intensity by amount
        currIntensity -= amount;
        // Update the particle systems to the new intensity
        UpdateIntensities();
        // Update currentlyLit based on currIntensity
        if(currIntensity <= 0) {
            currentlyLit = false;
            // Send extinguished message if not sent already to CountdownTracker
            if (!extinguishedMessageSent) {
                extinguishedMessageSent = true;
                countdownTrackerRef.extinguishedFire();
            }
            // return true when fire has been extinguished
            return true;
        }
        // return false if fire hasn't been extinguished
        return false;
    }

    // Update is called once per frame
    void UpdateIntensities()
    {
        // Change each intensity based on what currIntensity is
        for (int i = 0; i < fireParticleSystem.Length; i++) {
            var emission = fireParticleSystem[i].emission;
            emission.rateOverTime = currIntensity * startingIntensities[i];
        }
    }
}
