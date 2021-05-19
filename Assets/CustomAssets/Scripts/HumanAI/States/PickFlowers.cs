using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//[CreateAssetMenu(fileName = "PickFlowers", menuName = "ScriptableObjects/PickFlowers", order = 2)]
public class PickFlowers : BaseState
{

    public override void UpdateBehavior()
    {
        if (path.Count > 0)
            Patroling();
    }



    public override void StayPut()
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

    void pickUpFlower()
    {
        target = null;
        GameObject f = path[walkPoint].pathHolder;
        path.RemoveAt(walkPoint);
        Destroy(f);
    }
}
