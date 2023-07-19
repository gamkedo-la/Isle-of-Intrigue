using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    private GameObject player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            player = PlayerManager.Instance.GetPlayer();
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
