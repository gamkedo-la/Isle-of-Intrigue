using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1BoatBehaviour : MonoBehaviour
{
    public float rotationRange = 5f; // Range of rotation motion
    public float rotationSpeed = 2f; // Speed at which the boat rotates


    public float movementSpeed = 2f;

    public Transform playerShip;


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

        GetInRange();

    }

    public float GetInRange()
    {
        float distance = Vector3.Distance(this.transform.position, playerShip.position);

        if (distance >= 7)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        return distance;

    }


}