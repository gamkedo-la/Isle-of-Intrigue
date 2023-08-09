using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{

    public GameObject blastVfx;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Destroyable object got hit by a bullet!");
            if (blastVfx) {
                GameObject vfx = Instantiate(blastVfx, other.transform.position, Quaternion.identity);
                Destroy(vfx, 3f);
            }
            Destroy(this.gameObject); // the crate/barrel
            Destroy(other.gameObject); // the bullet
        }
    }    
}
