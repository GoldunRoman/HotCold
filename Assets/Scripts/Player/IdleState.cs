using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player, IPlayerStatesSwitcher stateSwitcher)
        : base(player, stateSwitcher)
    {
    }

    public override void Idle()
    {
        if(_player.speed == 0f)
        {
            _player.animator.SetTrigger("Idle");
        }
    }

    public override void Walk()
    {
    }

    public override void PickUpThing()
    {
    }

    public override void PickDownThing()
    {
    }

    public override void Jump()
    {
    }

    public override void CheckDistanceToGift()
    {
    }


}

