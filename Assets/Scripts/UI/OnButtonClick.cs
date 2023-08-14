using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{
    public GameObject menu;

    public enum ButtonFunctions
    {
        PLAY,
        MENU,
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
            case ButtonFunctions.MENU:
                GetComponent<Button>().onClick.AddListener(MENU);
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
        SettleTimeScale();
        SceneManager.LoadScene("Level");
    }
    void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    void MENU()
    {
        SettleTimeScale();
        SceneManager.LoadScene("Menu");
    }

    void RESUME()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    private void SettleTimeScale()
    {
        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
    }
}
