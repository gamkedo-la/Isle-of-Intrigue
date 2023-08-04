using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletSpray = 45f;
    public float maxShootDistance;
    Gameobject player;

    private void Awake()
    {
        player = GameObject.FindwithTag("Player");
        Shoot();
    }

    public void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;

        // Calculate the direction from the player to the mouse
        Vector2 directionFromPlayer = (mousePosition - player.transform.position).normalized;

        // Calculate the angle between the direction to the mouse and the direction from the player
        float angleDifference = Vector2.Angle(directionToMouse, directionFromPlayer);

        // Check if the angle difference is greater than 90 degrees (mouse is at the back of the player)
        if (angleDifference > 90f)
        {
            // Do not shoot if the mouse is at the back of the player
            return;
        }

        // Check if the distance between the player and the mouse is within the shooting range
        if (Vector3.Distance(player.position, mousePosition) < maxShootDistance)
        {
            // Do not shoot if the mouse is too close to the player
            return;
        }

        // Apply inaccuracy to the shooting direction
        float randAngleOffset = Random.Range(-0.5f, 0.5f) * bulletSpray;
        Quaternion inaccuracyQuat = Quaternion.AngleAxis(randAngleOffset, Vector3.forward);
        Vector2 inaccuracyDirection = inaccuracyQuat * directionToMouse;

        GetComponent<Rigidbody2D>().velocity = inaccuracyDirection * bulletSpeed;
        float angle = Mathf.Atan2(inaccuracyDirection.y, inaccuracyDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}

private void OnCollisionEnter(Collision other)
{
    if (other.gameObject.CompareTag("enemy"))
    {
        Destroy(this.gameObject);
    }
}



