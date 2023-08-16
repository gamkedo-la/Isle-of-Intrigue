using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInvisibilityController : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth health;
    private SpriteRenderer[] spriteRenderers;
    private bool isTogglingVisibility;


    void Start()
    {
        spriteRenderers = player.GetComponentsInChildren<SpriteRenderer>();
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
                    foreach (var renderer in spriteRenderers)
                    {
                        renderer.enabled = false;
                    }

                    player.GetComponent<Collider2D>().enabled = false;
                    isTogglingVisibility = false;
                }
            }
            else
            {
                if (context.canceled)
                {
                    foreach (var renderer in spriteRenderers)
                    {
                        renderer.enabled = true;
                    }

                    player.GetComponent<Collider2D>().enabled = true;
                    isTogglingVisibility = true;
                }
            }
        }
    }
}

