using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowingBomb : MonoBehaviour
{
    public Transform player;

    public GameObject bombPrefab;

    public Transform throwingPoint;
    public Transform enemy;

    public Animator animator;
    public float throwForce = 10f;

    private float throwTimer;




    void Start()
    {
        throwTimer = Random.Range(1, 3);
        StartCoroutine(BombAnim());
    }


    private IEnumerator BombAnim()
    {
        do
        {
            yield return new WaitForSeconds(throwTimer);

            animator.SetTrigger("bomb");


        } while (gameObject.activeInHierarchy);


    }


    public void ThrowBombTowardsPlayer()
    {

        Vector2 directionToPlayer = player.position - enemy.transform.position;
        directionToPlayer.Normalize();

        GameObject bomb = Instantiate(bombPrefab, throwingPoint.position, Quaternion.identity);

        Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
        bombRb.AddForce(directionToPlayer * throwForce, ForceMode2D.Impulse);


    }



}
