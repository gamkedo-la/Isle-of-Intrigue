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

        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        randomDirection.Normalize();

        Vector3 finalDirection = (transform.right + randomDirection * shakeIntensity).normalized;

        GetComponent<Rigidbody2D>().velocity = finalDirection * baseSpeed;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, initialPosition) >= 1f)
        {
            GetComponent<Rigidbody2D>().AddForce((initialPosition - transform.position).normalized * shakeIntensity, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(blastVfx, collision.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
