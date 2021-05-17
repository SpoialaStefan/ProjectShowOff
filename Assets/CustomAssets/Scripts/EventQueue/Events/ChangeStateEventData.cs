using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateEventData : EventData
{
    public HumanStates state;
    public ChangeStateEventData(HumanStates newState) : base(EventType.CHANGESTATE)
    {
        state = newState;
    }
}
