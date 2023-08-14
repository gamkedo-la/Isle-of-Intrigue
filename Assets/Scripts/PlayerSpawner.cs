using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform player;
    public AudioClip spawnSound;
    private Transform initialPos;
    bool playerActive;
    Rigidbody2D rb;

    private void Start()
    {
        rb = player.gameObject.GetComponent<Rigidbody2D>();
        initialPos = player.transform;
        playerActive = true;
    }


    public void SpawnPlayer()
    {
       
            player.position += Vector3.up * 10.0f;
            AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position);
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            Invoke("StaticPlayer", 2f);
    }

    private void StaticPlayer()
    {
        StartCoroutine(CheckPlayer());
    }

    IEnumerator CheckPlayer()
    {
        do
        {
            yield return new WaitForSeconds(0.1f);

            if (player.gameObject.activeInHierarchy)
            {
                playerActive = false;
                rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
                player.position = initialPos.position;
            }

        } while (playerActive);
       
    }

}
