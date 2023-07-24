using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeEnemy : MonoBehaviour
{
    public GameObject explosionVfx;
    public float vfxDestroyDelay = 1f;

    public AudioClip bombSound;

    int enemyLayer;
    int grenadeLayer;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        grenadeLayer = LayerMask.NameToLayer("GrenadeEnemy");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == enemyLayer || other.gameObject.layer == grenadeLayer)
        {
            return;
        }

        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionVfx, other.contacts[0].point, transform.rotation);
        AudioSource.PlayClipAtPoint(bombSound, Camera.main.transform.position);
        Destroy(explosion, vfxDestroyDelay);

    }

}
