using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;

    public List<GameObject> weapons = new List<GameObject>();
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
        Debug.Log("call");

        if (died)
        {
            deathCounter++;
            animator.SetBool("die", true);
            Invoke("Spawn", 2);
            currentHealth = 10;

            foreach (GameObject weapon in weapons)
            {
                if (weapon.activeInHierarchy)
                {
                    weapon.SetActive(false);
                    break;
                }
                else
                {
                    continue;
                }
            }

        }

    }

    private void Spawn()
    {
        if (deathCounter >= 3)
        {
            return;
        }

        else
        {
            died = false;
            currentHealth = 3;
            animator.SetBool("die", false);
            spawner.SpawnPlayer();
        }
    }


    public bool DieStatus()
    {
        return died;
    }

}
