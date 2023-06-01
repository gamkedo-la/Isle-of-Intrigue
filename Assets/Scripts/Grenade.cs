using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionVfx;
    public float vfxDestroyDelay = 1f;

    void Start()
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        int grenadeLayer = LayerMask.NameToLayer("Grenade");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Ignore collision with player, do not instantiate VFX
            return;

        }
        Destroy(gameObject, 1f);
        GameObject explosion = Instantiate(explosionVfx, other.contacts[0].point, transform.rotation);
        Destroy(explosion, vfxDestroyDelay);

    }


}
