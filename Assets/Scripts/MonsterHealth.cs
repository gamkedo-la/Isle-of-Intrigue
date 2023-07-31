using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public float damage = 3f;
    public Animator animator;
    bool died;

    private void Awake()
    {
        died = false;
    }

    private void Update()
    {
        if (damage <= 0)
        {
            EnemyDie();
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(other.gameObject);

            if (!died)
            {
                animator.SetTrigger("damage");
                TakeDamage(1);
            }

        }
    }

    private void TakeDamage(float hurtAmmount)
    {
        damage -= hurtAmmount;
    }

    private void EnemyDie()
    {

        if (!died)
        {
            died = true;
            animator.SetTrigger("die");
        }

    }


    public bool EnemyDieIndicator()
    {
        return died;
    }
}
