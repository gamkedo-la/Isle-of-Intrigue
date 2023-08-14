using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseHandling : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public void Pause(InputAction.CallbackContext context)
    {
       pauseMenu.SetActive(true); 
        Time.timeScale = 0f;
    }
}
