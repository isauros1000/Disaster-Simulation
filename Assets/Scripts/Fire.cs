using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Range(0f,1f)]
    public float currIntensity = 1.0f;
    public float[] startingIntensities = new float[0];

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

    // Update is called once per frame
    void Update()
    {
        // Change each intensity based on what currIntensity is
        for (int i = 0; i < fireParticleSystem.Length; i++) {
            var emission = fireParticleSystem[i].emission;
            emission.rateOverTime = currIntensity * startingIntensities[i];
        }
    }
}
