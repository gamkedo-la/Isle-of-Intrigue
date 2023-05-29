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
    public GameObject bulletShellPrefab;
    public GameObject firePoint;
    public Transform shotContainer;

    public GameObject bombPrefab; // Prefab of the bomb object
    public float throwForce = 10f; // Force applied to the thrown bomb

    public bool hideMouseCursor = false;

    public Transform weaponToShake;
    public float weaponShakeTimespan = 0.1f;
    public Vector3 weaponShakeDistance = new Vector3(-0.2f,0,0);
    private float weaponShakeTimeLeft = 0f;
    private Vector3 weaponToShakePivot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCounter = 0;
        if (hideMouseCursor) Cursor.lockState = CursorLockMode.Locked;

        if (this.weaponToShake) {
            this.weaponToShakePivot = this.weaponToShake.transform.localPosition;
        }

    }

    private void FixedUpdate()
    {
        PlayerMovement();
        WeaponShake();
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

            if (muzzleFlashPrefab) {
                GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, firePoint.transform.position, firePoint.transform.rotation);
                muzzleFlash.transform.SetParent(firePoint.transform); // stay stuck to gun muzzle
                muzzleFlash.transform.Rotate(0,90,90); // point forward
                muzzleFlash.transform.localPosition = new Vector3(4.0f,0.5f,0f); // <--- fixme: should just be firePoint, not sure why we need to set this
            }

            if (bulletShellPrefab) {
                GameObject shell = Instantiate(bulletShellPrefab, firePoint.transform.position, firePoint.transform.rotation);
                shell.transform.SetParent(shotContainer);
                //shell.transform.Rotate(0,90,90); // point forward
                //shell.transform.localPosition = new Vector3(3.0f,0.5f,0f);
                // strange how all the xforms are off.. must be the parent?
                Debug.Log("eject! "+shell.transform.localPosition);
            }

            this.weaponShakeTimeLeft = this.weaponShakeTimespan; // start kickback

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

    // wiggle the player and weapon - "kickback"
    private void WeaponShake()
    {
        if (!this.weaponToShake) return;

        if (this.weaponShakeTimeLeft > 0f) {

            float perc = this.weaponShakeTimeLeft / this.weaponShakeTimespan;
            if (perc>1f) perc = 1f;
            if (perc<0f) perc = 0f;
            
            this.weaponToShake.transform.localPosition = Vector3.Lerp(this.weaponToShakePivot,this.weaponToShakePivot+this.weaponShakeDistance,perc);
            
            this.weaponShakeTimeLeft -= Time.deltaTime;
            if (this.weaponShakeTimeLeft <= 0f) { // done!
                this.weaponToShake.transform.localPosition = this.weaponToShakePivot;
            }

            

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
