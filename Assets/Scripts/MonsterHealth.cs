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

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(other.gameObject);

            if (!died && damage > 0)
            {
                StartCoroutine(ChangeColorAndTakeDamage(0.5f, 1f));
            }

            else
            {
                EnemyDie();
            }

        }
    }

   
    private IEnumerator ChangeColorAndTakeDamage(float colorDuration, float hurtAmount)
    {

        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(colorDuration);

        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;

        TakeDamage(hurtAmount);

        if (damage <= 0 && !died)
        {
            EnemyDie();
        }
    }

    private void TakeDamage(float hurtAmmount)
    {
        damage -= hurtAmmount;
    }

    private void EnemyDie()
    {
        died = true;
        animator.SetTrigger("die");
    }


    public bool EnemyDieIndicator()
    {
        return died;
    }
}
