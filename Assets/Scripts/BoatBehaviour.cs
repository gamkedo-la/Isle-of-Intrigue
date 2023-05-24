using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    public float rotationRange = 5f; // Range of rotation motion
    public float rotationSpeed = 2f; // Speed at which the boat rotates

    public float movementSpeed = 2f;

    public float driftSpeed = 1f; // Speed of drift motion

    private float startingRotation;

    private void Start()
    {
        startingRotation = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        // Calculate the rotation motion
        float rotationOffset = Mathf.Sin(Time.time * driftSpeed) * rotationRange;
        float newRotation = startingRotation + rotationOffset;

        // Apply the rotation motion to the boat
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newRotation);

        // Move the boat forward
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
}


