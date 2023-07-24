using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    public float rotationRange = 5f; // Range of rotation motion
    public float rotationSpeed = 2f; // Speed at which the boat rotates

    public float movementSpeed = 2f;

    public float driftSpeed = 1f;

    private float startingRotation;

    private void Start()
    {
        startingRotation = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        float rotationOffset = Mathf.Sin(Time.time * driftSpeed) * rotationRange;
        float newRotation = startingRotation + rotationOffset;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newRotation);

        //  transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }
}


