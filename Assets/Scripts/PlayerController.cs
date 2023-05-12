using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform shotContainer;
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    private Vector2 move;
    public float jumpForce = 10f;
    private bool isGrounded;

    private int jumpCounter;

    public GameObject bulletPrefab;
    public GameObject firePoint;

    public float bulletSpeed = 10f;
    public float bulletSpray = 45f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCounter = 0;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }


    public void Move(InputAction.CallbackContext context)
    {
        move = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (isGrounded && context.performed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCounter++;

            if (jumpCounter >= 2)
            {
                isGrounded = false;
                jumpCounter = 0;
            }
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            float randAngleOffset = Random.Range(-0.5f, 0.5f) * bulletSpray;
            Quaternion inaccuracyQuat = Quaternion.AngleAxis(randAngleOffset, Vector3.forward);
            Vector2 direction = inaccuracyQuat * (mousePosition - transform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            bullet.transform.SetParent(shotContainer);
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
