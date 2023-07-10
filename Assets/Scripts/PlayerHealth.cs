using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public Animator animator;


    void Update()
    {
        HealthStatus();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHealth = 0;
    }

    private void HealthStatus()
    {
        if (currentHealth == 0)
        {
            FinishThePlayer();
        }

    }


    private void FinishThePlayer()
    {
        animator.SetBool("Die", true);
    }

}
