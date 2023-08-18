using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{

    public GameObject blastVfx;
    public AudioClip blastSfx;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("enemyBullet"))
        {
            if (blastVfx) {
                GameObject vfx = Instantiate(blastVfx, other.transform.position, Quaternion.identity);
                Destroy(vfx, 3f);
            }
            if (blastSfx) {
                AudioSource.PlayClipAtPoint(blastSfx, Camera.main.transform.position);
            }
            Destroy(this.gameObject); // the crate/barrel
            Destroy(other.gameObject); // the bullet
        }
    }    
}
