using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState : MonoBehaviour
{
    public bool isStateFinished = false;
    public HumanStates state;
    public abstract void UpdateBehavior();
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Transform self;


    private void Start()
    {
        agent = FindObjectOfType<NavMeshAgent>();
        self = agent.transform;

    }
    [System.Serializable]
    public class PathWay
    {
        public GameObject pathHolder;
        public float timeToStay = 4;
    }



    public bool IsStateFinished()
    {
        return isStateFinished;
    }

    public void FinishState()
    {
        isStateFinished = true;
    }



}
