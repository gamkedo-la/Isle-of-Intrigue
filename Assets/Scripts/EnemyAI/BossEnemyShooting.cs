using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShooting : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform playerShip;
    public float movementSpeed;
    public Transform shootingPoint;

    public PlayerHealth playerHealth;

    Rigidbody2D rigid;

    public AudioClip rifleShootingAudio;

    public float bulletSpeed = 10f;

    public Transform container;
    public float shootCooldown = 1.0f;
    public float shootDistance = 10.0f;

    private bool canShoot = true;

    public Animator animator;

    PlayerHealth health;

    public MonsterHealth monsterHealth;

    Coroutine AttackRoutine;

    private bool move;

    int rand;



    void Start()
    {
        rigid = bulletPrefab.GetComponent<Rigidbody2D>();
        AttackRoutine = StartCoroutine(BossAttack());
        rand = Random.Range(8, 16);
        health = player.GetComponent<PlayerHealth>();
        move = true;
    }

    void Update()
    {
        if (canShoot && !monsterHealth.EnemyDieIndicator() && !GetInRange())
        {
            Shoot();
            StartCoroutine(ShootCooldownTimer());
        }

        if (monsterHealth.EnemyDieIndicator() == true) ;
        {

            StopCoroutine(AttackRoutine);
        }

    }

    private void Shoot()
    {
        Vector3 playerPosition = player.position;
        float distance = Vector3.Distance(playerPosition, shootingPoint.position);
        if (distance <= shootDistance)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(rifleShootingAudio, Camera.main.transform.position);
            Vector2 direction = ((Vector2)playerPosition - (Vector2)shootingPoint.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            bullet.transform.parent = container;
        }
    }

    private IEnumerator ShootCooldownTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);


        canShoot = true;

    }

    public void PlayerDamage()
    {
        playerHealth.TakeDamage(3);
    }

    public IEnumerator BossAttack()
    {
        do
        {
            yield return new WaitForSeconds(rand);
            animator.SetTrigger("attack");

        } while (!playerHealth.DieStatus());
    }

    public bool GetInRange()
    {
        float distance = Vector3.Distance(this.transform.position, playerShip.position);
        Debug.Log(distance);

        if (distance >= 40)
        {
            Vector2 direction = (playerShip.position - this.transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);
            move = true;
        }
        else
        {
            move = false;
        }

        return move;

    }


}
