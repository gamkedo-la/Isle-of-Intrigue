using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructAfterTime : MonoBehaviour
{
    public float timeAlive = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeAlive);
    }

}
