using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDisconnectEventData : EventData
{
    public ClientDisconnectEventData() : base(EventType.CLIENTDISCONNESCT) { }
}
