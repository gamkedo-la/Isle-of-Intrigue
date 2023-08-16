using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    public float speed = 10f;
    public GameObject blastVfx;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject vfx = Instantiate(blastVfx, collision.transform.position, Quaternion.identity);
        Destroy(vfx, 1f);
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}
