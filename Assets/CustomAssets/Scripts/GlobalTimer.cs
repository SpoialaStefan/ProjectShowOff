using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum GardenZones
{
    WildPatch,
    FlowerGarden,
    VegetableGarden
}

public class GlobalTimer : MonoBehaviour
{
    [SerializeField]
    int minutes;
    [SerializeField]
    int seconds;

    [SerializeField]
    int minutesForFirstEvent;
    [SerializeField]
    int secondsForFirstEvent;

    [SerializeField]
    int minutesForSecondEvent;
    [SerializeField]
    int secondsForSecondEvent;

    [SerializeField]
    int minutesForThirdEvent;
    [SerializeField]
    int secondsForThirdEvent;

    [SerializeField]
    float timer;

    float timeForFirstEvent;
    float timeForSecondEvent;
    float timeForThirdEvent;

    bool firstEventFired=false;
    bool secondEventFired=false;
    bool thirdEventFired=false;

    private void Awake()
    {
        timer = minutes * 60 + seconds;

        timeForFirstEvent =timer-( minutesForFirstEvent * 60 + secondsForFirstEvent);
        timeForSecondEvent = timer - (minutesForSecondEvent * 60 + secondsForSecondEvent);
        timeForThirdEvent = timer - (minutesForThirdEvent * 60 + secondsForThirdEvent);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;


        if (timer < timeForFirstEvent&&firstEventFired==false)
        {
            Debug.Log("FirstEvent");
            ChangeStateEvent();
            firstEventFired = true;
        }
        if (timer < timeForSecondEvent && secondEventFired == false)
        {
            Debug.Log("SecondEvent");
            ChangeStateEvent();
            secondEventFired = true;
        }
        if (timer < timeForThirdEvent && thirdEventFired == false)
        {
            Debug.Log("ThirdtEvent");
            ChangeStateEvent();
            thirdEventFired = true;
        }
    }

    private static void ChangeStateEvent()
    {
        HumanStates state = GameManager.gameManager.GetPlayerPositionZone();
        Debug.Log(state);
        EventQueue.eventQueue.AddEvent(new ChangeStateEventData(state));
    }
}
