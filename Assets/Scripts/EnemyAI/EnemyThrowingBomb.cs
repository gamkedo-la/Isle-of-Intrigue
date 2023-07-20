using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowingBomb : MonoBehaviour
{
    public Transform player;
    public GameObject bombPrefab;

    public Animator animator;
    public float throwForce = 10f;


    private void Update()
    {
        if (player != null)
        {
            animator.SetTrigger("throw");
        }
    }

    public void ThrowBombTowardsPlayer()
    {

        Vector2 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();

        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);

        Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
        bombRb.AddForce(directionToPlayer * throwForce, ForceMode2D.Impulse);


    }
}
