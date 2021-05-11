using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarCollect : MonoBehaviour
{
    [SerializeField]
    int nectarAmount = 0;

    private void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.NECTARCOLLECTEND, OnNectarIsCollected);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.GetComponent<NectarDistributor>())
            {
                EventQueue.eventQueue.AddEvent(new NectarCollectStartEventData());
            }
        }
    }

    public void OnNectarIsCollected(EventData eventData)
    {
        if(eventData is NectarCollectEndEventData)
        {
            NectarCollectEndEventData e = eventData as NectarCollectEndEventData;
            changeNectarAmount(e.nectarAmount);
        }
    }

    private void changeNectarAmount(int amount)
    {
        nectarAmount += amount;
        Debug.Log("New nectar amount: "+nectarAmount);
    }
}
