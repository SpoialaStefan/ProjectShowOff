using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarTrunk : MonoBehaviour
{
    [SerializeField]
    int nectarAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.NECTARSTORED, OnNectarIsStored);
    }

    private void changeNectarAmount(int amount)
    {
        nectarAmount += amount;
        Debug.Log("New nectar amount in trunk: " + nectarAmount);
    }

    public void OnNectarIsStored(EventData eventData)
    {
        if(eventData is NectarIsStoredEventData)
        {
            NectarIsStoredEventData e = eventData as NectarIsStoredEventData;
            changeNectarAmount(e.nectarAmount);
        }
    }
}
