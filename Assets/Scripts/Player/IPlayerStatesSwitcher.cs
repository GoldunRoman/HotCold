using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStatesSwitcher
{
    void SwitchState<T>() where T : State;
}
