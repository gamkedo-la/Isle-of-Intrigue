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
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int hurt)
    {
        currentHealth -= hurt;
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
