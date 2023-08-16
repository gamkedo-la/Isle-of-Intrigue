using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInvisibilityController : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth health;
    private SpriteRenderer[] spriteRenderers;
    public List<GameObject> weapons = new List<GameObject>();
    private bool isTogglingVisibility;
    private bool invisible;


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
                        invisible = true;
                    }

                    foreach (GameObject weapon in weapons)
                    {
                        weapon.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    }


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
                        invisible = false;
                    }

                    foreach (GameObject weapon in weapons)
                    {
                        weapon.GetComponentInChildren<SpriteRenderer>().enabled = true;

                    }

                    isTogglingVisibility = true;
                }
            }
        }
    }

    public bool GetInvisibility()
    {
        return invisible;
    }
}

