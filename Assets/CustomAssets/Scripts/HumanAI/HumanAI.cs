using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum HumanStates
{
    WalkInTheGarden,
    PickFlowes,
    SprayGarden,
    CutGrass
}

public class HumanAI : MonoBehaviour
{
    [SerializeField]
    GameObject stateHolder;
    List<BaseState> states;
    BaseState currentState;
    // Start is called before the first frame update
    void Start()
    {
        //states.Add(stateHolder.GetComponent<MoveInGarden>());

        Debug.Log(stateHolder.GetComponent<PickFlowers>());
        PickFlowers pe = stateHolder.GetComponent<PickFlowers>();
        Debug.Log(pe);
        //states.Add(pe);
        //states.Add(stateHolder.GetComponent<SprayPesticides>());

        currentState = stateHolder.GetComponent<PickFlowers>();
        Debug.Log(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState!=null)
        currentState.UpdateBehavior();
    }

    public void OnStateChange(EventData eventData)
    {
        if(eventData is ChangeStateEventData)
        {
            ChangeStateEventData e = eventData as ChangeStateEventData;
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].state == e.state)
                {
                    currentState = states[i];
                    break;
                }
            }
        }
    }
}
