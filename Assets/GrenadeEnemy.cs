using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeEnemy : MonoBehaviour
{    

    private int enemyLayer;
    private int grenadeLayer;
    private ExplosionManager explosionObjectPool;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        grenadeLayer = LayerMask.NameToLayer("GrenadeEnemy");
        explosionObjectPool = FindObjectOfType<ExplosionManager>();

        if (explosionObjectPool == null)
        {
            Debug.LogError("Explosion Object Pool not found in the scene.");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == enemyLayer || other.gameObject.layer == grenadeLayer)
        {
            return;
        }

        Destroy(gameObject);

        if (explosionObjectPool != null)
        {
            GameObject explosionVfx = explosionObjectPool.GetExplosionVFX();

            if (explosionVfx != null)
            {
                ContactPoint2D contact = other.contacts[0]; 
                explosionVfx.transform.position = contact.point; 
                explosionVfx.transform.rotation = Quaternion.identity; 

            }
        }
    }

}
