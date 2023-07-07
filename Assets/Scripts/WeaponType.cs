using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponType : MonoBehaviour
{

    public List<GameObject> weapons = new List<GameObject>();

    public GameObject pistolPrefab;
    public GameObject riflePrefab;
    public GameObject rocketLauncherPrefab;

    public Animator animator;

    public enum WeaponState
    {
        Pistol,
        MachineGun,
        RocketLauncher,
    }

    public WeaponState currentWeaponType;


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
                weapon.SetActive(true);
                SetAnimationLayerWeight(currentWeaponTag, 1);
                Debug.Log("matched");
                break;
            }
        }
    }

    private void SetAnimationLayerWeight(string layerName, int weight)
    {
        int layerIndex = animator.GetLayerIndex(layerName);
        Debug.Log(layerName);
        animator.SetLayerWeight(layerIndex, weight);
        Debug.Log(layerIndex);
    }
}
