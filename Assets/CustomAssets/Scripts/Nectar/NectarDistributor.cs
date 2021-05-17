using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarDistributor : MonoBehaviour
{
    [SerializeField]
    private int nectarAmount;

    private void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.NECTARCOLLECTSTART, OnNectarIsCollected);
    }

    public void OnNectarIsCollected(EventData eventData)
    {
        if (eventData is NectarCollectStartEventData)
        {
            NectarCollectStartEventData e = eventData as NectarCollectStartEventData;
            if (e.dis == this)
            {
                EventQueue.eventQueue.AddEvent(new NectarCollectEndEventData(nectarAmount));
                EventQueue.eventQueue.UnSubscribe(EventType.NECTARCOLLECTSTART, OnNectarIsCollected);
                Destroy(gameObject);
            }
        }
    }
}
