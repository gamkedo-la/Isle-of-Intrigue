using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{
    public GameObject PauseMenu;

    public enum ButtonFunctions
    {
        PLAY,
        BACK,
        CREDITS,
        RESUME
    }
    public ButtonFunctions function;

    void Start()
    {
        switch (function)
        {
            case ButtonFunctions.PLAY:
                GetComponent<Button>().onClick.AddListener(Play);
                break;
            case ButtonFunctions.BACK:
                GetComponent<Button>().onClick.AddListener(BACK);
                break;
            case ButtonFunctions.CREDITS:
                GetComponent<Button>().onClick.AddListener(Credits);
                break;
            case ButtonFunctions.RESUME:
                GetComponent<Button>().onClick.AddListener(RESUME);
                break;
        }
    }

    void Play()
    {
        SceneManager.LoadScene("Level");
    }
    void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    void BACK()
    {
        SceneManager.LoadScene(0);
    }

    void RESUME()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
