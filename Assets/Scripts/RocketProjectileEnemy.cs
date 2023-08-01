using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectileEnemy : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject explosionPrefab;
    public float missileSpeed = 10f;

    public float turnSpeed = 2f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody missileRigidbody = GetComponent<Rigidbody>();

        if (missileRigidbody != null)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            missileRigidbody.velocity = directionToPlayer * missileSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }


}