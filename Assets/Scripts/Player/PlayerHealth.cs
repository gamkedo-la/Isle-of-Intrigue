using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;

    public List<GameObject> weapons = new List<GameObject>();
    public Animator animator;


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

    private void TakeDamage(int hurt)
    {
        currentHealth -= hurt;
    }

    private void HealthStatus()
    {
        if (currentHealth <= 0)
        {
            FinishThePlayer();
        }

    }


    private void FinishThePlayer()
    {
        animator.SetBool("die", true);
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
