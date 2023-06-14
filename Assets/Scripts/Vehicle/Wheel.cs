using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [Header("Suspension Settings")]
    public float SuspensionStrenght = 10f;
    public float SuspensionDamper;
    public float SuspensionHeight = 2f;
    public float SuspensionRestDistance = 1;

    [Header("Tire Settings")]
    public float TireMass = 1f;
    [Tooltip("Grip of tire based of % of max speed")]
    public AnimationCurve TireGripCurve;
    public Rigidbody vehicleRb;

    [Header("Wheel Settings")]
    public float MaxWheelRotationAngle = 45f;
    public float WheelRotationSpeed = 1000f;
    public bool InverseMovement = false;
    public bool IsAcceleratingWheel = false;
    public bool IsSteeringWheel = false;
    
    public BaseVehicle VehicleAttachedTo;
     
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit tireRay;
        GetRaycastHitFromTireToTheGround(out tireRay);
        if(IsSteeringWheel)
            SteerWheel(VehicleAttachedTo.PlayerInput.HorizontalInput);
        if(tireRay.transform)
        {
            CalculateSuspension(tireRay);
            CalculateSteeringForce();
            if(IsAcceleratingWheel)
            {
                CalculateAcceleration(VehicleAttachedTo.PlayerInput.VerticalInput, VehicleAttachedTo.EnginePowerCurve);
            }
        } 
    }


    float currentRotation = 0f;
    private void SteerWheel(float horizontalInput)
    {
        float rotationAmount = horizontalInput * WheelRotationSpeed * Time.deltaTime * (InverseMovement ? -1 : 1);
        currentRotation += rotationAmount;
        currentRotation = Mathf.Clamp(currentRotation, -MaxWheelRotationAngle, MaxWheelRotationAngle);
        Vector3 rotationVector = new Vector3(0.0f, currentRotation, 0.0f);
        transform.localRotation = Quaternion.Euler(rotationVector);
    }

    private void CalculateSuspension(RaycastHit tireRay)
    {
        Vector3 springDir = transform.up;

        Vector3 tireWorldVel = vehicleRb.GetPointVelocity(transform.position);

        float offset = SuspensionRestDistance - tireRay.distance;

        float vel = Vector3.Dot(springDir, tireWorldVel);

        float force = (offset * SuspensionStrenght) - (vel * SuspensionDamper);

        vehicleRb.AddForceAtPosition(springDir * force, transform.position);
        Debug.DrawRay(transform.position, springDir * force, Color.green);
    }

    private void CalculateSteeringForce()
    {
        Vector3 steeringDir = transform.right;

        Vector3 tireWorldVel = vehicleRb.GetPointVelocity(transform.position);

        float steeringVel = Vector3.Dot(steeringDir, tireWorldVel);

        float desiredVelChange = -steeringVel * TireGripCurve.Evaluate(GetVehicleNormalizedSpeed());
        Debug.Log("Grip factor: " + TireGripCurve.Evaluate(GetVehicleNormalizedSpeed()));

        float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

        vehicleRb.AddForceAtPosition(steeringDir * TireMass * desiredAccel, transform.position);

        Debug.DrawRay(transform.position, steeringDir * TireMass * desiredAccel, Color.red);
    }

    private void CalculateAcceleration(float forwardInput, AnimationCurve powerCurve)
    {
        if (Mathf.Abs(forwardInput) < 0.05f)
            return;

        Vector3 accelDir = transform.forward;

        float avaliableTorque = powerCurve.Evaluate(GetVehicleNormalizedSpeed()) * forwardInput;

        vehicleRb.AddForceAtPosition(accelDir * avaliableTorque * VehicleAttachedTo.EnginePower, transform.position);

        Debug.DrawRay(transform.position, accelDir * avaliableTorque * VehicleAttachedTo.EnginePower, Color.blue);
    }

    private float GetVehicleNormalizedSpeed()
    {
        float carSpeed = Vector3.Dot(vehicleRb.transform.forward, vehicleRb.velocity);
        float normaizedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / VehicleAttachedTo.VehicleTopSpeed);
        return normaizedSpeed;
    }

    private void GetRaycastHitFromTireToTheGround(out RaycastHit hit)
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
        Physics.Raycast(ray, out hit, SuspensionHeight);
    }
}
