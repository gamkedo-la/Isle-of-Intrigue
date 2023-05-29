using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplets : MonoBehaviour
{
    public GameObject dropsPrefab;
    public float speed;

    void Start()
    {
        Instantiate(dropsPrefab, transform.position, transform.rotation);
        StartCoroutine(StartDropTimer());
        Cursor.visible = false;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    IEnumerator StartDropTimer()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            Instantiate(dropsPrefab, transform.position, transform.rotation);
        }


    }

}
