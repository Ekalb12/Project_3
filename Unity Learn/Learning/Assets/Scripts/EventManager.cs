using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventManager
{
    public static Action<int> OnCoinsCollected; // Int == Coins Collected

    public static Action<int> OnDeathTriggered; // Int == Current Health

    public static Action<int> OnGameOverTriggered;

}
