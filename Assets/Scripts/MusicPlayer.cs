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
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.Stop();
            yield return new WaitForSeconds(pauseDuration);
            audioSource.Play();
        }
    }
}
