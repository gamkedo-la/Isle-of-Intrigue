using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseHandling : MonoBehaviour
{
    public GameObject pauseMenu;
    bool pauseFlag;

    private void Start()
    {
        pauseFlag = false; 
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (!pauseFlag)
        {
            pauseMenu.SetActive(true);
            pauseFlag = true;
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            pauseFlag = false;
            Time.timeScale = 1;

        }
    }
}
