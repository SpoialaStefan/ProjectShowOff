using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//[CreateAssetMenu(fileName = "PickFlowers", menuName = "ScriptableObjects/PickFlowers", order = 2)]
public class PickFlowers : BaseState
{
    [SerializeField]
    private List<PathWay> path;


    private int walkPoint = -1;
    private bool walkPointSet;
    [SerializeField]
    private NavMeshAgent agent;
    private Transform target;
    [SerializeField]
    private Transform self;
    float timer = 5;
    //private void OnDrawGizmos()
    //{
    //    foreach (PathWay waypoint in path)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawSphere(waypoint.pathHolder.transform.position, .5f);
    //    }

    //}

    public override void UpdateBehavior()
    {
        if (path.Count > 0)
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
        GameObject f = path[walkPoint].pathHolder;
        path.RemoveAt(walkPoint);
        Destroy(f);
    }
}
