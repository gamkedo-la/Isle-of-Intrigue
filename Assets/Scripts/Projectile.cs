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
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;
        float distanceToMouse = Vector2.Distance(transform.position, mousePosition);
        float randAngleOffset = Random.Range(-0.5f, 0.5f) * bulletSpray;
        Quaternion inaccuracyQuat = Quaternion.AngleAxis(randAngleOffset, Vector3.forward);
        Vector2 inaccuracyDirection = inaccuracyQuat * directionToMouse;
        GetComponent<Rigidbody2D>().velocity = inaccuracyDirection * bulletSpeed;
        float angle = Mathf.Atan2(inaccuracyDirection.y, inaccuracyDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // FIXME: this never gets run?!
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Projectile hit "+other.gameObject.name);

        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("destroyable"))
        {
            Debug.Log("Destroyable hit by bullet!");
            Destroy(this.gameObject);
        }
    }


}








