using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Transform player;
    public GameObject bulletPrefab;

    public Transform shootingPoint;

    public Transform container;
    public float shootCooldown = 1.0f;
    public float shootDistance = 10.0f;


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
            bullet.transform.parent = container;
        }

    }

}

