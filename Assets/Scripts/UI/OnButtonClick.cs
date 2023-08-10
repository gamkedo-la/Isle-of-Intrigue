using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{

    public enum ButtonFunctions
    {
        PLAY,
        OPTIONS,
        CREDITS
    }
    public ButtonFunctions function;

    void Start()
    {
        switch (function)
        {
            case ButtonFunctions.PLAY:
                GetComponent<Button>().onClick.AddListener(Play);
                break;
            case ButtonFunctions.OPTIONS:
                GetComponent<Button>().onClick.AddListener(Options);
                break;
            case ButtonFunctions.CREDITS:
                GetComponent<Button>().onClick.AddListener(Credits);
                break;
        }
    }

    void Play()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level 1");
    }

    void Options()
    {
        Debug.Log("Clicked Options");
    }

    void Credits()
    {
        Debug.Log("Clicked Credits");
    }
}
