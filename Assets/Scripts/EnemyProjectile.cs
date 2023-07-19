using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    // public float bulletSpray = 45f;

    Rigidbody2D rigid;
    Vector2 direction;

    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        Shoot();
    }

    public void Shoot()
    {
        direction = (player.transform.position - transform.position).normalized;
        rigid.velocity = direction * bulletSpeed;
    }
}
