using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "SprayPesticides", menuName = "ScriptableObjects/SprayPesticides", order = 3)]
public class SprayPesticides : BaseState
{
    [SerializeField]
    private PathWay[] path;


    private int walkPoint = -1;
    private bool walkPointSet;

    private NavMeshAgent agent;
    private Transform target;
    private Transform self;
    private ParticleSystem particles;
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
        if(!particles.isPlaying)
        particles.Play();
        if (timer <= 0)
        {
            if (particles.isPlaying)
                particles.Stop();
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
