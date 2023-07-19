using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletSpray = 45f;

    Rigidbody2D rigid;



    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Shoot();
    }

    public void Shoot()
    {
        Vector2 direction = (transform.forward - transform.position).normalized;
        rigid.velocity = direction * bulletSpeed;
    }
}
