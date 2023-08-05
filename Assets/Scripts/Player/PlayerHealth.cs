using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public Animator animator;
    public PlayerSpawner spawner;

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
        died = true;

        if (died)
        {
            deathCounter++;
            animator.SetBool("die", true);
            Invoke("Spawn", 2);
            currentHealth = 10;
            Debug.Log(deathCounter);
        }

    }

    private void Spawn()
    {
        if (deathCounter >= 3)
        {

            for (var i = 0; i < animator.layerCount; i++)
            {
                animator.SetLayerWeight(i, 0);
            }

        }

        else
        {
            died = false;
            currentHealth = 10;
            animator.SetBool("die", false);
            spawner.SpawnPlayer();
        }
    }


    public bool DieStatus()
    {
        return died;
    }



}
