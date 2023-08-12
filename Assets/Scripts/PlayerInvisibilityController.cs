using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInvisibilityController : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth health;
    private bool isTogglingVisibility;


    void Awake()
    {
        isTogglingVisibility = true;
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!health.DieStatus())
        {
            if (isTogglingVisibility)
            {
                Debug.Log(context);
                if (context.started)
                {
                    player.SetActive(false);
                    isTogglingVisibility = false;
                }

            }

            if (!isTogglingVisibility)
            {
                if (context.canceled)
                {
                    Debug.Log("check");

                    player.SetActive(true);
                    isTogglingVisibility = true;
                }
            }
        }

      
    }

}