using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireExtinguisher : MonoBehaviour
{
    public float extinguishRate = 0.1f;
    public ParticleSystem waterhose;
    
    public void Start()
    {
        // Stop the water particle system from the beginning
        waterhose.Stop();
    }
    //Method for starting the water particle system
    public void ShowUp()
    {
        waterhose.Play();
    }
    public void Extinguish()
    {   // Since the velocityOverLifetime is a struct, get a reference to it
        var waterhoseRef = waterhose.velocityOverLifetime;
        // Update the velocities to shoot forward
        waterhoseRef.x = transform.forward.x * 25;
        waterhoseRef.y = transform.forward.y * 25;
        waterhoseRef.z = transform.forward.z * 25;
        // If the Raycast hits the fire's collider, extinguish it using fire's TryExtinguish
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 50f)) {
            if(hitInfo.collider.gameObject.name == "ExtinguisherCollider") {
                hitInfo.collider.GetComponentInParent<Fire>().TryExtinguish(extinguishRate * Time.deltaTime);
            }
        }
    }
    //Method for stopping the water particle system
    public void StopPlaying()
    {
        waterhose.Stop();
    }
}
