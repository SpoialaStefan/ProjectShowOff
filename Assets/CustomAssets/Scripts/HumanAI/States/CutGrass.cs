using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutGrass : BaseState
{
    //[SerializeField]
    //private List<PathWay> path;

    [SerializeField]
    private GameObject pointToStartCutting;
    [SerializeField]
    private GameObject pointToEndCutting;

   // private int walkPoint = -1;
    //private bool walkPointSet;

    //[SerializeField]
    //private NavMeshAgent agent;
    //private Transform target;
    //[SerializeField]
    //private Transform self;
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private GameObject lawnmower;
    [SerializeField]
    private GameObject launge;
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

    public override void HandleTargetreached()
    {
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
        base.HandleTargetreached();
    }
}
