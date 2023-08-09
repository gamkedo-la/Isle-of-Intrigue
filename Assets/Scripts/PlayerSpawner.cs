using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform player;
    public AudioClip spawnSound;
    private Transform initialPos;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = player.gameObject.GetComponent<Rigidbody2D>();
        initialPos = player.transform;
    }


    public void SpawnPlayer()
    {
        player.position += Vector3.up * 10.0f;
        AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position);
        rb.isKinematic = false;
        Invoke("StaticPlayer", 2f);
    }

    private void StaticPlayer()
    {
        rb.isKinematic = true;
        player.position = initialPos.position;
    }

 

   


}
