using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplets : MonoBehaviour
{
    public GameObject dropsPrefab;
    public float speed;

    void Start()
    {
        Invoke("StartingFunction", Random.value);
    }

    void StartingFunction()
    {
        GameObject tempDrop = Instantiate(dropsPrefab, transform.position, transform.rotation);
        Destroy(tempDrop, 1.0f); 
        StartCoroutine(StartDropTimer());
        // Cursor.visible = false;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    IEnumerator StartDropTimer()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
            GameObject tempDrop = Instantiate(dropsPrefab, transform.position, transform.rotation);
            Destroy(tempDrop, 1.0f); 
        }
    }

}
