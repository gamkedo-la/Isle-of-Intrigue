using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform player;
    public AudioClip spawnSound;
    private Transform initialPos;
    Rigidbody2D rb;

    private void Start()
    {
        rb = player.gameObject.GetComponent<Rigidbody2D>();
        initialPos = player.transform;
    }


    public void SpawnPlayer()
    {
       
            player.position += Vector3.up * 10.0f;
            AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position);
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(StaticPlayer());
    }

    IEnumerator  StaticPlayer()
    {
        yield return new WaitForSeconds(2f);
        rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        player.position = initialPos.position;
    }



}
