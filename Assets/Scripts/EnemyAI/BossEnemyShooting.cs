using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    public float detectionRange = 5f;

    private Transform player;
    private bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            Vector2 direction = player.position - transform.position;
            transform.right = direction;

            if (canShoot)
            {
                Shoot();
                StartCoroutine(ShootDelay());
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.right * bulletSpeed;
    }

    private System.Collections.IEnumerator ShootDelay()
    {
        canShoot = false;

        yield return new WaitForSeconds(1f / fireRate);

        canShoot = true;
    }

}
