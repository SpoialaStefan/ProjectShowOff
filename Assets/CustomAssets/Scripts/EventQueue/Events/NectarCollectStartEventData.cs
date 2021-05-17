using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarCollectStartEventData : EventData
{
    public NectarDistributor dis;
    public NectarCollectStartEventData(NectarDistributor nec) : base(EventType.NECTARCOLLECTSTART) { dis = nec; }
}

