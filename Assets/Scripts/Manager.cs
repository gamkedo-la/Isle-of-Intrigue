using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject ship2;
    public GameObject SeaMonster;


    private void Ship2Activation()
    {

        ship2.SetActive(true);
    }

    private void SeaMonsterActivation()
    {
        SeaMonster.SetActive(true);
    }
}
