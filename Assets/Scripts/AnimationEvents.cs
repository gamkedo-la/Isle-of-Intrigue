using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public PlayerController player;

    public void CallBombAnimations()
    {
        player.BombAttack();
    }

    public void CallJump()
    {
        player.JumpNow();
    }

}
