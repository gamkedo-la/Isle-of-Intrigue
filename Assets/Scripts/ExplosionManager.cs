using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public GameObject explosionVfxPrefab;
    public int poolSize = 20;

    private List<GameObject> explosionVfxPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject explosionVfx = Instantiate(explosionVfxPrefab);
            explosionVfx.SetActive(false);
            explosionVfxPool.Add(explosionVfx);
        }
    }

    public GameObject GetExplosionVFX()
    {
        foreach (GameObject vfx in explosionVfxPool)
        {
            if (!vfx.activeSelf)
            {
                StartCoroutine(ReturnExplosionVFX(vfx));
                vfx.SetActive(true);
                return vfx;

            }
        }

        return null;
    }

    IEnumerator ReturnExplosionVFX(GameObject explosionVfx)
    {
        yield return new WaitForSeconds(2);
        explosionVfx.SetActive(false);
    }
}
