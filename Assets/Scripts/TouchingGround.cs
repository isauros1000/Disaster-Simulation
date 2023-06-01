using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingGround : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get a reference to the score
        ScoreTracking scoreRef = gameObject.GetComponent<ScoreTracking>();
        // Create the Ray object that the raycast will do
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 10)) {
            // Get the info from the collision to see if we're touching ground
            if(hitInfo.collider.gameObject.CompareTag("Ground")) {
                // Decrease score because we're off the road
                scoreRef.score -= 1*Time.fixedDeltaTime;
            }
        }

    }
}
