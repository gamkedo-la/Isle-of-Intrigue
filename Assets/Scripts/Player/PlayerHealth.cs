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
    public AudioClip playerDie;
    public GameObject GameOverMenu;
    public List<GameObject> enemyShooting = new List<GameObject>();

    private int deathCounter;

    bool died;



    private void Awake()
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
            TakeDamage(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Grenade") || other.gameObject.CompareTag("enemyMissile"))
        {
            if (!died)
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

    private void FinishThePlayer()
    {

        if (!died)
        {
            died = true;
            deathCounter++;
            animator.SetBool("die", true);
            Invoke("Spawn", 2);
            AudioSource.PlayClipAtPoint(playerDie,Camera.main.transform.position);

        }

    }

    public void GameEnd() {

        foreach (GameObject enemy in enemyShooting)
        {
            enemy.SetActive(false);
        }

        for (var i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        shipAnimator.SetTrigger("sink");
        AudioSource.PlayClipAtPoint(waterSplash, Camera.main.transform.position);
        GameOverMenu.SetActive(true);
    }


    public bool DieStatus()
    {
        return died;
    }



}
