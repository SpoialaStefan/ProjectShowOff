﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    void pickUpFlower()
    {
        target = null;
        GameObject f = path[walkPoint].pathHolder;
        path.RemoveAt(walkPoint);
        Destroy(f);
    }
}
