using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfController : MonoBehaviour
{
    public DwarfChain dwarfChain;
    public Animator animator;
    public Animator ship1Animator;
    public Animator ship2Animator;

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

        ship1Animator.SetTrigger("sink");
        Destroy(ship1Animator.gameObject, 5f);
    }

    public void Ship2Sink()
    {

        ship2Animator.SetTrigger("sink");
        Destroy(ship2Animator.gameObject, 5f);

    }


}
