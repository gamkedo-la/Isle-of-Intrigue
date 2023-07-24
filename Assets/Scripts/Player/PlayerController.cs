using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;



public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Projectile projectile;

    private GameObject bulletPrefab;

    public GameObject muzzleFlashPrefab;
    public GameObject bulletShellPrefab;
    private GameObject firePoint;
    public Light2D muzzleFlashLight;
    public Transform shotContainer;

    public Animator animator;
    public GameObject bombPrefab; // Prefab of the bomb object
    public float throwForce = 10f; // Force applied to the thrown bomb

    public bool hideMouseCursor = false;


    public Transform weaponToShake;
    public float weaponShakeTimespan = 0.1f;
    public Vector3 weaponShakeDistance = new Vector3(-0.2f, 0, 0);

    public Light2D light;

    private Vector2 move;
    private bool isGrounded;
    private int jumpCounter;

    bool crouch;
    bool right;

    bool pistol;
    bool rocket;

    private float weaponShakeTimeLeft = 0f;
    private Vector3 weaponToShakePivot;

    public GameObject GrenadePos;

    public WeaponType weaponManager;

    private bool machineGunFlag;
    private bool RocketLauncherFlag;

    public AudioClip pistolSound;

    public AudioClip rifleSound;

    public AudioClip rocketSound;


    void Start()
    {
        right = true;
        crouch = false;
        machineGunFlag = false;
        rb = GetComponent<Rigidbody2D>();
        jumpCounter = 0;
        if (hideMouseCursor) Cursor.lockState = CursorLockMode.Locked;

        if (this.weaponToShake)
        {
            this.weaponToShakePivot = this.weaponToShake.transform.localPosition;
        }

        isGrounded = true;

        pistol = true;
        bulletPrefab = weaponManager.pistolPrefab;
        firePoint = weaponManager.weapons[0].transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        MovementCheck();
        WeaponShake();
    }

    public void SetActiveBulletPrefab()
    {

        switch (weaponManager.currentWeaponType)
        {
            case WeaponType.WeaponState.MachineGun:
                pistol = false;
                rocket = false;
                machineGunFlag = true;
                bulletPrefab = weaponManager.riflePrefab;
                firePoint = weaponManager.weapons[1].transform.GetChild(0).gameObject;



                break;

            case WeaponType.WeaponState.RocketLauncher:
                pistol = false;
                machineGunFlag = false;
                rocket = true;

                bulletPrefab = weaponManager.rocketLauncherPrefab;
                firePoint = weaponManager.weapons[2].transform.GetChild(0).gameObject;
                break;

            default:
                Debug.LogWarning("Unknown active weapon type");
                break;
        }

    }


    public void Move(InputAction.CallbackContext context)
    {
        move = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("jump");
        }
    }

    public void JumpNow()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

    }


    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("crouch", true);
            crouch = true;
        }


        if (context.canceled)
        {
            animator.SetBool("crouch", false);
            crouch = false;
        }
    }

    private void DisableMuzzleLight()
    {
        muzzleFlashLight.enabled = false;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (bulletPrefab != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
                bullet.transform.SetParent(shotContainer);
                light.intensity = 4;
                BulletAudio();


                if (machineGunFlag == true)
                {
                    if (muzzleFlashPrefab)
                    {
                        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, firePoint.transform.position, firePoint.transform.rotation);
                        muzzleFlash.transform.SetParent(firePoint.transform); // stay stuck to gun muzzle
                        muzzleFlash.transform.Rotate(0, 90, 90); // point forward
                        muzzleFlash.transform.localPosition = new Vector3(4.0f, 0.5f, 0f); // <--- fixme: should just be firePoint, not sure why we need to set this

                        muzzleFlashLight.enabled = true;
                        Invoke(nameof(DisableMuzzleLight), 0.1f);
                    }


                    if (bulletShellPrefab)
                    {
                        GameObject shell = Instantiate(bulletShellPrefab, firePoint.transform.position, firePoint.transform.rotation);
                        shell.transform.SetParent(shotContainer);
                        Debug.Log("eject! " + shell.transform.localPosition);
                    }

                    this.weaponShakeTimeLeft = this.weaponShakeTimespan; // start kickback

                }

            }

            if (bulletPrefab == null)
            {
                animator.SetTrigger("attack");
            }

        }

        else
        {

            light.intensity = 0;
        }
    }

    public void ThrowingBomb(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("throw");
            Debug.Log("Throwing");
        }
    }

    public void BulletAudio()
    {
        if (pistol == true)
        {
            AudioSource.PlayClipAtPoint(pistolSound, Camera.main.transform.position);
        }

        if (machineGunFlag == true)
        {
            AudioSource.PlayClipAtPoint(rifleSound, Camera.main.transform.position);
        }

        if (rocket == true)
        {
            AudioSource.PlayClipAtPoint(rocketSound, Camera.main.transform.position);
        }
    }

    public void BombAttack()
    {
        Debug.Log("Bomb");
        GameObject bomb = Instantiate(bombPrefab, GrenadePos.transform.position, Quaternion.identity);
        Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();
        bombRigidbody.AddForce(Vector2.right * throwForce, ForceMode2D.Impulse);
    }



    private void PlayerMovement()
    {
        Vector2 movement = move * moveSpeed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

    }

    private void MovementCheck()
    {
        if (rb.velocity.x < 0.0f)
        {
            animator.SetBool("move", true);
            animator.SetFloat("IdleInput", -1);
            animator.SetFloat("Input", -1);
            right = false;

        }
        else if (rb.velocity.x > 0.0f)
        {
            animator.SetBool("move", true);
            animator.SetFloat("IdleInput", 1);
            animator.SetFloat("Input", 1);
            right = true;

        }

        if (Mathf.Approximately(rb.velocity.x, 0.0f))
        {
            if (right)
            {
                animator.SetBool("move", false);
                animator.SetFloat("Input", 0);
                animator.SetFloat("IdleInput", 1);

            }
            else
            {
                animator.SetBool("move", false);
                animator.SetFloat("Input", 0);
                animator.SetFloat("IdleInput", -1);

            }
        }


    }


    // wiggle the player and weapon - "kickback"
    private void WeaponShake()
    {
        if (!this.weaponToShake) return;

        if (this.weaponShakeTimeLeft > 0f)
        {

            float perc = this.weaponShakeTimeLeft / this.weaponShakeTimespan;
            if (perc > 1f) perc = 1f;
            if (perc < 0f) perc = 0f;

            this.weaponToShake.transform.localPosition = Vector3.Lerp(this.weaponToShakePivot, this.weaponToShakePivot + this.weaponShakeDistance, perc);

            this.weaponShakeTimeLeft -= Time.deltaTime;
            if (this.weaponShakeTimeLeft <= 0f)
            { // done!
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
