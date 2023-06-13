using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();

    public enum WeaponState
    {
        Pistol,
        MachineGun,
        RocketLauncher,
    }

    private WeaponState currentWeaponType;

    public void ChangeWeaponState(WeaponState targetWeaponState)
    {

        currentWeaponType = targetWeaponState;

        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        string currentWeaponTag = currentWeaponType.ToString();

        foreach (GameObject weapon in weapons)
        {
            if (weapon.CompareTag(currentWeaponTag))
            {
                Debug.Log("Hogya Jan");
                weapon.SetActive(true);
                break;
            }
        }
    }
}
