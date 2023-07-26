using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerController player;
    public Transform spawnPos;

    public Animator animator;


    public void SpawnPlayer()
    {
        player.transform.position = spawnPos.position;
    }
}
