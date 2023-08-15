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
    public AudioClip attack1;
    public AudioClip attack2;
    private AudioClip[] attacks;
    public AudioClip roar1;
    public AudioClip roar2;
    public AudioClip roar3;
    private AudioClip[] roars;
    private bool attack;


    public Animator animator;

    PlayerHealth health;

    public MonsterHealth monsterHealth;

    Coroutine AttackRoutine;
    Coroutine RoarRoutine;

    private bool move;

    int randomAttackWaitTime;


    private int getAttackInterval()
    {
        return Random.Range(8, 16);
    }


    void Start()
    {
        attacks = new AudioClip[2];
        attacks[0] = attack1;
        attacks[1] = attack2;
        roars = new AudioClip[3];
        roars[0] = roar1;
        roars[1] = roar2;
        roars[2] = roar3;
        attack = false;

        rigid = bulletPrefab.GetComponent<Rigidbody2D>();
        AttackRoutine = StartCoroutine(BossAttack());
        randomAttackWaitTime = getAttackInterval();
        health = player.GetComponent<PlayerHealth>();
        move = false;
        RoarRoutine = StartCoroutine(MonsterRoar());
    }

    

    void Update()
    {
        if (canShoot && !monsterHealth.EnemyDieIndicator())
        {
            
                Shoot();
                StartCoroutine(ShootCooldownTimer());
            
          
        }

        if (monsterHealth.EnemyDieIndicator() == true) 
        {

            StopCoroutine(AttackRoutine);
            StopCoroutine(RoarRoutine);
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
        if (attack)
        {
            playerHealth.TakeDamage(3);
            attack = false;
        }
    }

    public IEnumerator BossAttack()
    {
        do
        {
            yield return new WaitForSeconds(randomAttackWaitTime);
            randomAttackWaitTime = getAttackInterval();
            animator.SetTrigger("attack");
            AudioSource.PlayClipAtPoint(getNextAttackSound(), Camera.main.transform.position);

        } while (gameObject.activeInHierarchy);
    }

    IEnumerator MonsterRoar()
    {
        do
        {
            yield return new WaitForSeconds(3);
            AudioSource.PlayClipAtPoint(getNextRoarSound(), Camera.main.transform.position);
        } while (gameObject.activeInHierarchy);
    }

    private AudioClip getNextAttackSound()
    {
        return attacks[Random.Range(0, attacks.Length)];
    }
    
    private AudioClip getNextRoarSound()
    {
        return roars[Random.Range(0, roars.Length)];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attack = true;
        }
    }


}
