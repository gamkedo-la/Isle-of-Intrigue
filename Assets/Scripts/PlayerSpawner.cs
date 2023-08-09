using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public  Transform player;
    public Transform spawnPos;
    public PlayerHealth health;
    public AudioClip spawnSound;




    public void SpawnPlayer()
    {
        player.position += Vector3.up * 5.0f;
    }
}
