using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public Animator animator;
    public PlayerSpawner spawner;
    public Animator shipAnimator;
    public AudioClip waterSplash;
    public PlayerInvisibilityController controller;
    public AudioClip playerDie;
    public GameObject GameOverMenu;
    public GameObject monster;
    public List<GameObject> enemyShooting = new List<GameObject>();
    public List<GameObject> weapons = new List<GameObject>();

    private int deathCounter;

    bool died;



    private void Start()
    {
        deathCounter = 0;
        died = false;
    }


    void Update()
    {
        HealthStatus();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            Destroy(other.gameObject);

            if (!controller.GetInvisibility())
            {
                TakeDamage(1);
            }

        }

        if (other.gameObject.CompareTag("Grenade") || other.gameObject.CompareTag("enemyMissile"))
        {
            Destroy(other.gameObject);

            if (!controller.GetInvisibility())
            {
                Invoke("FinishThePlayer", 0.5f);
            }
        }
    }

    public void TakeDamage(int hurt)
    {
        currentHealth -= hurt;
    }

    private void HealthStatus()
    {
        if (currentHealth <= 0 && died == false)
        {
            FinishThePlayer();
        }

    }

    private void FinishThePlayer()
    {
        if (!died)
        {
            died = true;
            deathCounter++;
            animator.SetBool("die", true);
            AudioSource.PlayClipAtPoint(playerDie, Camera.main.transform.position);

            if (!monster.activeInHierarchy)
            {
                StartCoroutine(PlayerSpawning());
            }

            else
            {
                StartCoroutine(PlayerDying());

            }

        }
    }

    IEnumerator PlayerSpawning()
    {
        yield return new WaitForSeconds(2);
        Spawn();
    }

    IEnumerator PlayerDying()
    {
        yield return new WaitForSeconds(2);
        GameEnd();
    }

    private void Spawn()
    {

        if (deathCounter >= 3)
        {
            GameEnd();
        }

        else
        {
            died = false;
            currentHealth = 10;
            animator.SetBool("die", false);
            spawner.SpawnPlayer();
        }
    }


    public void GameEnd() {

        foreach (GameObject enemy in enemyShooting)
        {
            enemy.SetActive(false);
        }

        foreach (GameObject weapon in weapons)
        {
           weapon.GetComponent<SpriteRenderer>().enabled = false;
        }

        shipAnimator.SetTrigger("sink");
        AudioSource.PlayClipAtPoint(waterSplash, Camera.main.transform.position);
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public bool DieStatus()
    {
        return died;
    }



}
