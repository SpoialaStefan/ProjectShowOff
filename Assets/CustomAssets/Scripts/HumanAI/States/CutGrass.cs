using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutGrass : BaseState
{
    [SerializeField]
    private List<PathWay> path;

    [SerializeField]
    private GameObject pointToStartCutting;
    [SerializeField]
    private GameObject pointToEndCutting;

    private int walkPoint = -1;
    private bool walkPointSet;

    //[SerializeField]
    //private NavMeshAgent agent;
    private Transform target;
    //[SerializeField]
    //private Transform self;
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private GameObject lawnmower;
    [SerializeField]
    private GameObject launge;
    float timer = 5;

    private void OnDrawGizmos()
    {
        foreach (PathWay waypoint in path)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(waypoint.pathHolder.transform.position, .3f);
        }

    }
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
            if (path[walkPoint].pathHolder == pointToStartCutting)
            {
                if (!particles.isPlaying)
                    particles.Play();
                if (lawnmower.activeSelf == false)
                {
                    lawnmower.SetActive(true);
                }
            }

            if (path[walkPoint].pathHolder == pointToEndCutting)
            {
                if (particles.isPlaying)
                    particles.Stop();
                if (lawnmower.activeSelf == true)
                {
                    lawnmower.SetActive(false);
                }
                if (launge.activeSelf == false)
                {
                    launge.SetActive(true);
                }
            }
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
        if (walkPoint > path.Count - 1 || walkPoint < 0) walkPoint = 0;
        target = path[walkPoint].pathHolder.transform;
        timer = path[walkPoint].timeToStay;
        walkPointSet = true;
    }
}
