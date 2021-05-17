using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "PickFlowers", menuName = "ScriptableObjects/PickFlowers", order = 2)]
public class PickFlowers : BaseState
{
    [SerializeField]
    private List< PathWay> path;


    private int walkPoint = -1;
    private bool walkPointSet;

    private NavMeshAgent agent;
    private Transform target;
    private Transform self;
    float timer = 5;


    public override void UpdateBehavior()
    {
        throw new System.NotImplementedException();
    }


    void Patroling()
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
            // walkPointSet = false;

            StayPut();

        }

    }

    void StayPut()
    {
        agent.SetDestination(self.position);
        if (timer <= 0)
        {
            pickUpFlower();
            walkPointSet = false;
            //timer = 5;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
        // Debug.Log(timer);
    }

    void SearchWalkPoint()
    {
        walkPoint++;
        if (walkPoint > path.Count - 1 || walkPoint < 0) walkPoint = 0;
        target = path[walkPoint].pathHolder.transform;
        timer = path[walkPoint].timeToStay;
        walkPointSet = true;
    }

    void pickUpFlower()
    {
        target = null;
        path.RemoveAt(walkPoint);
    }
}
