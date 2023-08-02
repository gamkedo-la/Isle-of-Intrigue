using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectileEnemy : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject explosionPrefab;
    public float missileSpeed = 10f;

    public float turnSpeed = 2f;

    Rigidbody2D missileRigidbody;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        missileRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (missileRigidbody != null)

        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            missileRigidbody.velocity = directionToPlayer * missileSpeed;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject vfx = Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
        Destroy(vfx, 2f);
    }


}