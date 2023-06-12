using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBadgePickUp : MonoBehaviour
{
    public WeaponType weaponType;

    public WeaponType.WeaponState currentWeaponState;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WeaponType weaponTypeScript = FindObjectOfType<WeaponType>();
            if (weaponTypeScript != null)
            {
                weaponTypeScript.ChangeWeaponState(currentWeaponState);
                gameObject.SetActive(false); // Deactivate the badge pickup
            }
        }
    }
}
