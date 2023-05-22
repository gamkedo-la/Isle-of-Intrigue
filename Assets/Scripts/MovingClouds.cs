using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    public float minSpeed = 1f; // Minimum speed of cloud movement
    public float maxSpeed = 3f; // Maximum speed of cloud movement

    private float cloudSpeed; // Actual speed of each cloud
    private float cloudWidth; // Width of each cloud
    private bool movingRight; // Direction of cloud movement

    private void Start()
    {
        // Generate a random speed for each cloud
        cloudSpeed = Random.Range(minSpeed, maxSpeed);

        // Get the width of each cloud
        cloudWidth = GetComponent<SpriteRenderer>().bounds.size.x;

        // Randomly set the initial direction of each cloud
        movingRight = Random.value > 0.5f;
    }

    private void Update()
    {
        // Calculate the cloud's movement direction
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;

        // Move the cloud horizontally
        transform.Translate(direction * cloudSpeed * Time.deltaTime);

        // Check if the cloud has moved off the screen
        if (movingRight && transform.position.x > Screen.width + cloudWidth / 2f)
        {
            // Move the cloud to the left side of the screen
            Vector2 newPosition = new Vector2(-cloudWidth / 2f, transform.position.y);
            transform.position = newPosition;
        }
        else if (!movingRight && transform.position.x < -cloudWidth / 2f)
        {
            // Move the cloud to the right side of the screen
            Vector2 newPosition = new Vector2(Screen.width + cloudWidth / 2f, transform.position.y);
            transform.position = newPosition;
        }
    }
}
