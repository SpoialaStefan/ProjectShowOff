﻿using System.Collections;
using System.Collections.Generic;


public enum EventType
{
    CLIENTCONNECT,
    CLIENTDISCONNESCT,
    STARTGAME,
    NECTARCOLLECTSTART,
    NECTARCOLLECTEND,
    NECTARSTORED,
    CHANGESTATE,
    PLAYERPESTICIDECOLLISION
}
public class EventData 
{
    public EventType eventType;
    public EventData(EventType type)
    {
        eventType = type;
    }

}
