using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowingBomb : MonoBehaviour
{
    public Transform player;

    public PlayerHealth playerHealth;
    public GameObject bombPrefab;

    public Transform throwingPoint;

    public Animator animator;
    public float throwForce = 10f;

    public float throwTimer;



    void Start()
    {
        StartCoroutine(BombAnim());
    }


    private IEnumerator BombAnim()
    {
        do
        {
            yield return new WaitForSeconds(throwTimer);

            animator.SetTrigger("bomb");


        } while (!playerHealth.DieStatus());


    }


    public void ThrowBombTowardsPlayer()
    {

        Vector2 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();

        GameObject bomb = Instantiate(bombPrefab, throwingPoint.position, Quaternion.identity);

        Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
        bombRb.AddForce(directionToPlayer * throwForce, ForceMode2D.Impulse);


    }



}
