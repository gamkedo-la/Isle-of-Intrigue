using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    AudioSource src;

    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        src.Play();
    }
}
