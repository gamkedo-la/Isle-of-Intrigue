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
    public PlayerController player;


    public Animator animator;

    public enum WeaponState
    {
        Pistol,
        MachineGun,
        RocketLauncher,
    }

    public WeaponState currentWeaponType;


    private void Awake()
    {
        CleanAnimatorLayersWeight();
        animator.SetLayerWeight(1, 1);

    }

    public void ChangeWeaponState(WeaponState targetWeaponState)
    {
        CleanAnimatorLayersWeight();
        currentWeaponType = targetWeaponState;

        player.SetActiveBulletPrefab();


        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        string currentWeaponTag = currentWeaponType.ToString();

        foreach (GameObject weapon in weapons)
        {
            if (weapon.CompareTag(currentWeaponTag))
            {
                SetAnimationLayerWeight(currentWeaponTag, 1);
                break;
            }
        }


    }

    private void CleanAnimatorLayersWeight()
    {

        for (var i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
    }

    private void SetAnimationLayerWeight(string layerName, int weight)
    {
        int layerIndex = animator.GetLayerIndex(layerName);
        animator.SetLayerWeight(0, 0);
        animator.SetLayerWeight(layerIndex, weight);
    }
}
