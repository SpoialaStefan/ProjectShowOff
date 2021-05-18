using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]
    private HumanStates playerPosition;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
    }
    private void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.CHANGEZONE, OnPlayerZoneChanged);
    }

    public void OnPlayerZoneChanged(EventData eventData)
    {
        if(eventData is ChangePlayerLocationEventData)
        {
            ChangePlayerLocationEventData e = eventData as ChangePlayerLocationEventData;
            SetPlayerPositionZone(e.zone);
        }
    }

    public void SetPlayerPositionZone(HumanStates newZone)
    {
        playerPosition = newZone;
    }    
    
    public HumanStates GetPlayerPositionZone()
    {
        return playerPosition;
    }
}
