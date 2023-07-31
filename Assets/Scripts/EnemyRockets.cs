using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockets : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public GameObject missilePrefab; // Prefab of the missile
    public float missileSpeed = 10f; // Speed of the missile
    public float turnSpeed = 2f; // How quickly the missile turns towards the player
    public GameObject explosionPrefab; // Prefab of the explosion effect
    public float fireInterval = 3f; // Time interval between firing missiles

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform not assigned to EnemyMissileController!");
            return;
        }

        // Start the coroutine to fire missiles periodically
        StartCoroutine(FireMissilesRoutine());
    }

    // Coroutine to fire missiles periodically
    private System.Collections.IEnumerator FireMissilesRoutine()
    {
        while (true)
        {
            FireMissile();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void FireMissile()
    {
        // Instantiate the missile prefab at the enemy's position and rotation
        GameObject missileObject = Instantiate(missilePrefab, firePoint.position, transform.rotation);
        Rigidbody missileRigidbody = missileObject.GetComponent<Rigidbody>();

        if (missileRigidbody != null)
        {
            // Get the direction from the missile to the player
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // Set the missile's velocity to make it move towards the player
            missileRigidbody.velocity = directionToPlayer * missileSpeed;

            // Rotate the missile to face the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            missileRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, lookRotation, turnSpeed));

        }

    }

    // Called when the missile collides with something
    void OnCollisionEnter(Collision collision)
    {
        // Instantiate the explosion prefab at the collision point
        Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

        // Destroy the missile and the collided object (if it has a collider)
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
