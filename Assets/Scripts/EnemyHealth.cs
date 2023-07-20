using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float damage = 3f;
    public GameObject weapon;
    public Animator animator;


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
            animator.SetTrigger("damage");
            TakeDamage(1);
            Debug.Log("Collision");
        }
    }

    private void TakeDamage(float hurtAmmount)
    {
        damage -= hurtAmmount;
    }

    private void EnemyDie()
    {
        if (weapon == null)
        {
            return;
        }

        else
        {
            weapon.SetActive(false);
            animator.SetTrigger("Die");
        }

    }
}
