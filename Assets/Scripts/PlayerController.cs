using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    private Vector2 move = Vector2.zero;
    public float jumpForce = 10f;
    private bool isGrounded;

    public GameObject bulletPrefab;
    public GameObject firePoint;

    public float bulletSpeed = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }


    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (isGrounded && context.performed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // Calculate the direction from the player to the mouse position
            Vector2 direction = (mousePosition - transform.position).normalized;

            // Instantiate a new bullet prefab at the player's position
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

            // Set the bullet's velocity to the direction multiplied by the bullet speed
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the bullet's rotation to face the mouse
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        }
    }


    private void PlayerMovement()
    {
        Vector2 movement = move * moveSpeed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
