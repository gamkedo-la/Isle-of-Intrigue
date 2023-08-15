using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public Transform enemy;


    Rigidbody2D rigid;

    public AudioClip rifleShootingAudio;

    public float bulletSpeed = 10f;
    public float bulletSpray = 45f;


    public Transform container;

    public EnemyHealth enemyHealth;
    public float shootCooldown = 1.0f;
    public float shootDistance = 20f;

    private bool canShoot = true;


    void Start()
    {
        rigid = bulletPrefab.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canShoot)
        {
            Shoot();
            StartCoroutine(ShootCooldownTimer());
        }

    }

    private void Shoot()
    {
      
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            AudioSource.PlayClipAtPoint(rifleShootingAudio, Camera.main.transform.position,0.1f);
            float randAngleOffset = Random.Range(-0.5f, 0.5f) * bulletSpray;
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Quaternion inaccuracyQuat = Quaternion.AngleAxis(randAngleOffset, Vector3.forward);
            direction = inaccuracyQuat * direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bullet.transform.parent = container;
        
    }

    private IEnumerator ShootCooldownTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);

        if (!enemyHealth.EnemyDieIndicator())
        {
            canShoot = true;
        }
    }
}

