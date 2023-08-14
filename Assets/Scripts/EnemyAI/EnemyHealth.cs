using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float damage = 3f;
    public AudioClip enemyDamageSound;
    public Transform playerShip;
    public bool move;
    public Animator animator;

    public GameObject shootingMechanism;

    public RewardBadgeController rewardController;
    Coroutine colorRoutine;
    Color[] originalColors;

    bool died;


    private int deathCounter;

    private void Awake()
    {
        died = false;
        move = true;
    }



    private void Update()
    {
        if (!GetInRange())
        {
            shootingMechanism.SetActive(true);
        }



    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(other.gameObject);

            if (!died)
            {
                colorRoutine = StartCoroutine(ChangeColorAndTakeDamage(0.5f, 1f));

            }

        }

        if (other.gameObject.CompareTag("playerMissile"))
        {
            EnemyDie();
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

    public void StopShooting()
    {

        shootingMechanism.SetActive(false);

    }

    private IEnumerator ChangeColorAndTakeDamage(float colorDuration, float hurtAmount)
    {
        SpriteRenderer[] spriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            originalColors[i] = spriteRenderers[i].color ;
            spriteRenderers[i].color = Color.red; 
        }

        yield return new WaitForSeconds(colorDuration);

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = originalColors[i];
        }
        
        TakeDamage(hurtAmount);

        if (damage <= 0 && !died)
        {
            StopCoroutine(colorRoutine);
            EnemyDie();
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
                AudioSource.PlayClipAtPoint(enemyDamageSound, Camera.main.transform.position);
                //weapon.SetActive(false);
                animator.SetTrigger("die");
                Invoke("Destroy", 2f);
                StopShooting();
            }
        
    }


    public bool GetInRange()
    {
        float distance = Vector3.Distance(this.transform.position, playerShip.position);


        if (distance >= 20)
        {
            move = true;
        }

        else
        {

            move = false;
        }

        return move;

    }
}
