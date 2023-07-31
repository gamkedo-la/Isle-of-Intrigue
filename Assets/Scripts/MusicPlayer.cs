using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public float pauseDuration = 5f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    void PlayMusic()
    {
        audioSource.Play();
        StartCoroutine(LoopMusicWithPause());
    }

    IEnumerator LoopMusicWithPause()
    {
        while (true)
        {
            yield return new WaitForSeconds(35);
            audioSource.Pause();
            yield return new WaitForSeconds(pauseDuration);
            audioSource.UnPause();
        }
    }
}
