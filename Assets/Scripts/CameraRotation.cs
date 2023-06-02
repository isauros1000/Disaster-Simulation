using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private int turnSpeed = 50;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Turns camera left
        if (Input.GetKey(KeyCode.F)) {
            transform.Rotate(-Vector3.up*turnSpeed*Time.fixedDeltaTime);
        }
        // Turns camera right
        if (Input.GetKey(KeyCode.H)) {
            transform.Rotate(Vector3.up*turnSpeed*Time.fixedDeltaTime);
        }
        // Turns camera up
        if (Input.GetKey(KeyCode.T)) {
            transform.Rotate(Vector3.left*turnSpeed*Time.fixedDeltaTime);
        }
        // Turns camera right
        if (Input.GetKey(KeyCode.G)) {
            transform.Rotate(-Vector3.left*turnSpeed*Time.fixedDeltaTime);
        }
    }
}
