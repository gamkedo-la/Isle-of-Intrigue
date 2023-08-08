using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockets : MonoBehaviour
{
    public GameObject missilePrefab;
    public float fireInterval = 3f;
    public Transform firePoint;
    public PlayerHealth player;


    void Start()
    {

        StartCoroutine(FireMissilesRoutine());
    }

    private IEnumerator FireMissilesRoutine()
    {
        do
        {
            FireMissile();
            yield return new WaitForSeconds(fireInterval);
        } while (gameObject.activeInHierarchy);
    }

    void FireMissile()
    {
        if (!player.DieStatus())
        {
            GameObject missileObject = Instantiate(missilePrefab, firePoint.position, transform.rotation);
        }
    }
}
