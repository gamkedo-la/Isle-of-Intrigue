using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    private Vector2 move;
    public float jumpForce = 10f;
    private bool isGrounded;

    private int jumpCounter;

    public Projectile projectile;

    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public GameObject firePoint;
    public Transform shotContainer;

    public GameObject bombPrefab; // Prefab of the bomb object
    public float throwForce = 10f; // Force applied to the thrown bomb

    public bool hideMouseCursor = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCounter = 0;
        if (hideMouseCursor) Cursor.lockState = CursorLockMode.Locked;

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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bullet.transform.SetParent(shotContainer);

            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, firePoint.transform.position, firePoint.transform.rotation);
            muzzleFlash.transform.SetParent(firePoint.transform); // stay stuck to gun muzzle
            // I am not sure why we need to set any of this (affected by parent xforms, perhaps?)
            muzzleFlash.transform.Rotate(0,90,90); // point forward
            muzzleFlash.transform.localPosition = new Vector3(4.0f,0.5f,0f); // <--- -ifxme shoudl just be firePoint
            //muzzleFlash.transform.localScale.Set(1f,1f,1f);
            //muzzleFlash.transform.SetParent(shotContainer,true);

        }
    }

    public void ThrowingBomb(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Instantiate a new bomb object from the prefab
            GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);

            // Apply force to the bomb object in the desired direction
            Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();
            bombRigidbody.AddForce(Vector2.right * throwForce, ForceMode2D.Impulse);

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
