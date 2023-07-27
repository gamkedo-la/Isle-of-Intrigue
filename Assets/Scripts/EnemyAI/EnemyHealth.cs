using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float damage = 3f;
    public GameObject weapon;
    public AudioClip enemyDamageSound;
    public Animator animator;

    public RewardBadgeController rewardController;
    bool died;




    private int deathCounter;

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

        Debug.Log(died);
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
        if (weapon == null)
        {
            return;
        }

        else
        {
            if (!died)
            {
                died = true;
                AudioSource.PlayClipAtPoint(enemyDamageSound, Camera.main.transform.position);
                weapon.SetActive(false);
                animator.SetTrigger("die");
                Invoke("Destroy", 3f);
            }
        }


    }

    public void Destroy()
    {
        rewardController.TakeReward(this.transform.GetChild(0));
        gameObject.SetActive(false);

    }

    public bool EnemyDieIndicator()
    {
        return died;
    }
}
