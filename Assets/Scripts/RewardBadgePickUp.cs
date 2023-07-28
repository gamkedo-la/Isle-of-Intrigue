using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBadgePickUp : MonoBehaviour
{
    private WeaponType weaponType;
    public AudioClip rewardSound;

    public WeaponType.WeaponState currentWeaponState;

    void Start()
    {
        weaponType = FindObjectOfType<WeaponType>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(rewardSound, Camera.main.transform.position);
            WeaponType weaponTypeScript = FindObjectOfType<WeaponType>();
            if (weaponTypeScript != null)
            {
                weaponTypeScript.ChangeWeaponState(currentWeaponState);
                gameObject.SetActive(false);
            }
        }

    }


}
