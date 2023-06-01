using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    public float motorForce;
    public float breakForce;
    public float maxSteerAngle = 30;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheeTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
    }

    //Gets the input from the keyboard
    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        // Applies torque force to the front wheels
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        // Defaults to 0 if we're not breaking
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        // Apply the break force to all the wheels
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        // Changes the steering angles of the 
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;

        // We've updates all the colliders, let's update the meshes
        UpdateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }


    // Takes the transformation information from the collider and copies it to the wheel's transform
    private void UpdateWheel(WheelCollider collider, Transform wheelTransform)
    {
        // Variables to get the info returned by GetWorldPose
        Vector3 pos;
        Quaternion rot
        // Copies the position and rotation of the collider
;       collider.GetWorldPose(out pos, out rot);
        // Updates the meshes to follow the colliders
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}