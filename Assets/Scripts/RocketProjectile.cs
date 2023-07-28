using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    public float baseSpeed = 10f;
    public GameObject blastVfx;
    public float shakeIntensity = 1f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;

        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        Vector2 finalDirection = (Vector2.right + randomDirection * shakeIntensity).normalized;

        // Explicitly set z-component to 0 for both position and velocity
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        GetComponent<Rigidbody2D>().velocity = new Vector3(finalDirection.x, finalDirection.y, 0f) * baseSpeed;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, initialPosition) >= 1f)
        {
            // Explicitly set z-component to 0 for the force calculation
            Vector3 forceDirection = (initialPosition - transform.position).normalized;
            forceDirection.z = 0f;
            GetComponent<Rigidbody2D>().AddForce(forceDirection * shakeIntensity, ForceMode2D.Force);
        }

        // Reset the z-component of the velocity to zero to avoid upward/downward movement
        GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(blastVfx, collision.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
