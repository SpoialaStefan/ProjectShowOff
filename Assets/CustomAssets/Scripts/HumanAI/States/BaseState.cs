﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState : MonoBehaviour
{
    public bool isStateFinished = false;
    public HumanStates state;
    public virtual void UpdateBehavior()
    {
        Patroling();
    }

    [SerializeField]
    protected List<PathWay> path;


    protected int walkPoint = -1;
    protected bool walkPointSet;
    [HideInInspector]
    protected NavMeshAgent agent;
    [HideInInspector]
    protected Transform self;
    protected Transform target;
    protected float timer = 5;

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

    public void Patroling()
    {
        // Debug.Log("patrol");
        if (walkPointSet == false)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(target.position);
        }

        Vector3 distanceToLocation = self.position - target.position;


        if (distanceToLocation.magnitude < 1f)
        {
            HandleTargetreached();
        }

    }

    public virtual void HandleTargetreached()
    {
        StayPut();
    }
    public virtual void StayPut()
    {
        agent.SetDestination(self.position);
        if (timer <= 0)
        {
            walkPointSet = false;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    public void SearchWalkPoint()
    {
        walkPoint++;
        if (walkPoint > path.Count - 1 || walkPoint < 0) walkPoint = 0;
        target = path[walkPoint].pathHolder.transform;
        timer = path[walkPoint].timeToStay;
        walkPointSet = true;
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
