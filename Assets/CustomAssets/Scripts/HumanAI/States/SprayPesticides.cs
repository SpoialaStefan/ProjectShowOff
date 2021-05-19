using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SprayPesticides : BaseState
{

    [Tooltip("Add Pesticide Particle Effect attached to the Human")]
    [SerializeField]
    private ParticleSystem particles;

    private void OnDrawGizmos()
    {
        foreach (PathWay waypoint in path)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(waypoint.pathHolder.transform.position, .3f);
        }

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
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }

}
