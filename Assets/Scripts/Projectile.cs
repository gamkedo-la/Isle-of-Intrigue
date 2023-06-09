using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletSpray = 45f;

    private void Awake()
    {
        Shoot();
    }

    public void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float randAngleOffset = Random.Range(-0.5f, 0.5f) * bulletSpray;
        Quaternion inaccuracyQuat = Quaternion.AngleAxis(randAngleOffset, Vector3.forward);
        Vector2 direction = inaccuracyQuat * (mousePosition - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
