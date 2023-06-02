using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionVfx;
    public float vfxDestroyDelay = 1f;

    int playerLayer;
    int grenadeLayer;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        grenadeLayer = LayerMask.NameToLayer("Grenade");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == playerLayer || other.gameObject.layer == grenadeLayer)
        {
            return;
        }

        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionVfx, other.contacts[0].point, transform.rotation);
        Destroy(explosion, vfxDestroyDelay);

    }


}
