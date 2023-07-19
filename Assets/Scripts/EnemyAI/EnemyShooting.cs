using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Transform player;
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    public float bulletSpeed = 10f;

    public float bulletSpray = 45f;


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
            float randAngleOffset = Random.Range(-0.5f, 0.5f) * bulletSpray;
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Quaternion inaccuracyQuat = Quaternion.AngleAxis(randAngleOffset, Vector3.forward);
            direction = inaccuracyQuat * direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bullet.transform.parent = container;
        }

    }

}

