using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    private float cloudSpeed;
    private bool movingRight;

    public GameObject skyRightEdge;
    public GameObject skyLeftEdge;

    float cloudWidth;

    float skywidth;

    Vector2 direction;

    private void Start()
    {
        cloudSpeed = Random.Range(minSpeed, maxSpeed);

        movingRight = Random.value > 0.5f;

        direction = movingRight ? Vector2.right : Vector2.left;

    }

    private void Update()
    {

        transform.Translate(direction * cloudSpeed * Time.deltaTime);


        // Check if the cloud has moved off the screen
        if (movingRight && transform.position.x > skyRightEdge.transform.position.x)
        {
            // Move the cloud to the left side of the screen
            direction = Vector2.left;
        }
        else if (!movingRight && transform.position.x < skyLeftEdge.transform.position.x)
        {
            direction = Vector2.right;
        }
    }
}
