using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected readonly Player _player;
    protected readonly IPlayerStatesSwitcher _stateSwitcher;

    protected State(Player player, IPlayerStatesSwitcher stateSwitcher)
    {
        _player = player;
        _stateSwitcher = stateSwitcher;
    }

    public abstract void Idle();

    public abstract void Walk();

    public abstract void Jump();

    public abstract void PickUpThing();

    public abstract void PickDownThing();

    public abstract void CheckDistanceToGift();
}
