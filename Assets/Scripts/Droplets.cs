using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplets : MonoBehaviour
{
    public GameObject dropsPrefab;
    public float speed;

    void Start()
    {
        GameObject tempDrop = Instantiate(dropsPrefab, transform.position, transform.rotation);
        Destroy(tempDrop, 1.5f); 
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
            GameObject tempDrop = Instantiate(dropsPrefab, transform.position, transform.rotation);
            Destroy(tempDrop, 1.5f); 
        }


    }

}
