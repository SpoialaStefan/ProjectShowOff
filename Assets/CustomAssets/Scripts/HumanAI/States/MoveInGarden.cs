using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//[CreateAssetMenu(fileName = "MoveInGarden", menuName = "ScriptableObjects/MoveInGarden", order = 1)]
public class MoveInGarden : BaseState
{

   // [SerializeField]
   // private List<PathWay> path;


   // private int walkPoint = -1;
   // private bool walkPointSet;

    //[SerializeField]
    //private NavMeshAgent agent;
   // private Transform target;
    //[SerializeField]
    //private Transform self;
    //float timer = 5;

    private void OnDrawGizmos()
    {
        foreach (PathWay waypoint in path)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(waypoint.pathHolder.transform.position, .3f);
        }

    }
    public override void UpdateBehavior()
    {
        Patroling();
    }


}
