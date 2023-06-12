using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public enum weaponState
    {
        Pistol,
        MachineGun,
        RocketLauncher,
    }

    private weaponState currentWeaponType;


    public void ChangeWeaponState(weaponState targetWeaponState)
    {
        currentWeaponType = targetWeaponState;

        string currentWeaponTag = currentWeaponType.ToString();

        foreach (GameObject weapon in weapons)
        {
            if (weapon.CompareTag(currentWeaponTag.ToString()))
            {
                weapon.SetActive(true);
            }

            else
            {

                weapon.SetActive(false);
            }
        }
    }
}
