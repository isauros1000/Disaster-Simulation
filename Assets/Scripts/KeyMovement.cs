using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    private float moveInput;
    public float moveSpeed;

    private float turnInput;
    public float turnSpeed;
    public Rigidbody sphereRB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the movement input and cap the velocity
        moveInput = Input.GetAxisRaw("Vertical") * moveSpeed;
        
        //  Get the turning input
        turnInput = Input.GetAxisRaw("Horizontal") * turnSpeed;

        // Follow the sphere's position
        transform.position = sphereRB.position;
    }

    void FixedUpdate()
    {
        // Calculate the new rotation
        Vector3 rotation = new Vector3(0, turnInput * turnSpeed * Time.fixedDeltaTime, 0);
        // Change the rotation of the car body
        transform.Rotate(rotation, Space.World);
        // Move the sphere with force
        sphereRB.AddForce(transform.forward * moveInput);
        
    }
}
