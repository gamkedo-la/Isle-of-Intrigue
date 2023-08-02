using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPos;


    public void SpawnPlayer()
    {
        player.transform.position = spawnPos.position;
    }
}
