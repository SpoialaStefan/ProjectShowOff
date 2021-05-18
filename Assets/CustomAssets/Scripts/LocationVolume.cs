using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationVolume : MonoBehaviour
{
    public HumanStates zone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EventQueue.eventQueue.AddEvent(new ChangePlayerLocationEventData(zone));
            Debug.Log("Hello from the volume");
        }
    }
}
