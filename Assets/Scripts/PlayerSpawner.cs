using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public  Transform player;
    public Transform spawnPos;
    public PlayerHealth health;
    public AudioClip spawnSound;


    private void Start()
    {
        spawnPos.position = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        if (!health.DieStatus())
        {
            spawnPos.position = new Vector2(player.position.x, 0);
        }
    }

    public void SpawnPlayer()
    {
        player.position = new Vector2(spawnPos.position.x,32.3f);
    }
}
