using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//[CreateAssetMenu(fileName = "MoveInGarden", menuName = "ScriptableObjects/MoveInGarden", order = 1)]
public class MoveInGarden : BaseState
{

    [SerializeField]
    private PathWay[] path;


    private int walkPoint = -1;
    private bool walkPointSet;

    [SerializeField]
    private NavMeshAgent agent;
    private Transform target;
    [SerializeField]
    private Transform self;
    float timer = 5;


    public override void UpdateBehavior()
    {
        Patroling();
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
        if (walkPoint > path.Length - 1 || walkPoint < 0) walkPoint = 0;
        target = path[walkPoint].pathHolder.transform;
        timer = path[walkPoint].timeToStay;
        walkPointSet = true;
    }

}
