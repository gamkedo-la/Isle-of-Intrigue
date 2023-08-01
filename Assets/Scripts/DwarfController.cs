using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfController : MonoBehaviour
{
    public DwarfChain dwarfChain;
    public Animator animator;

    public Animator shipAnimator;

    public void StartCelebrating()
    {
        dwarfChain.GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = true;

        animator.SetBool("celebrate", true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("reward");
        }
    }

    public void Fade()
    {
        animator.SetTrigger("fade");
    }

    public void ShipSink()
    {

        shipAnimator.SetTrigger("sink");
    }
}
