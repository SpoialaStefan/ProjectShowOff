using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//[CreateAssetMenu(fileName = "SprayPesticides", menuName = "ScriptableObjects/SprayPesticides", order = 3)]
public class SprayPesticides : BaseState
{
   // [SerializeField]
    //private List<PathWay> path;


    //private int walkPoint = -1;
    //private bool walkPointSet;

    //[SerializeField]
    //private NavMeshAgent agent;
    //private Transform target;
    //[SerializeField]
    //private Transform self;
    [SerializeField]
    private ParticleSystem particles;
    //float timer = 5;

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

    public override void StayPut()
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
    }

}
