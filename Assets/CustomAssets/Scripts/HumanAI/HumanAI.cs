using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanStates
{
    GoToHouse,
    WalkInTheGarden,
    PickFlowes,
    SprayGarden,
    CutGrass
}

public class HumanAI : MonoBehaviour
{
    [SerializeField]
    List<BaseState> states;
    BaseState currentState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateBehavior();
    }

    public void OnStateChange(EventData eventData)
    {

    }
}
