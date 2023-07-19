using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Transform player;
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    public float bulletSpeed = 10f;

    Rigidbody2D rigid;


    public Transform container;
    public float shootCooldown = 1.0f;
    public float shootDistance = 10.0f;

    void Start()
    {
        rigid = bulletPrefab.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Shoot();
    }


    private void Shoot()
    {
        Vector3 playerPosition = player.position;
        float distance = Vector3.Distance(playerPosition, transform.position);
        if (distance <= shootDistance)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            Vector2 direction = (player.transform.position - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bullet.transform.parent = container;
        }

    }

}

