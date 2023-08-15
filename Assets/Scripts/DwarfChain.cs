using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DwarfChain : MonoBehaviour
{
    public int chainHealth;
    public DwarfController dwarfController;

    public Light2D glow;

    private void Awake()
    {
        glow.intensity = 0;
    }


    void Update()
    {

        if (chainHealth <= 0)
        {

            this.gameObject.SetActive(false);
            dwarfController.StartCelebrating();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            chainHealth -= 1;
            Destroy(other.gameObject);
            StartCoroutine(Glow());

        }

        if (other.gameObject.CompareTag("playerMissile"))
        {
            chainHealth = 0;
            Destroy(other.gameObject);
        }
    }

    IEnumerator Glow()
    {
        glow.intensity = 2;

        yield return new WaitForSeconds(0.1f);

        glow.intensity = 0;
    }
}
