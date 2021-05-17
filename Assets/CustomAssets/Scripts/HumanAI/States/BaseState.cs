using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState:ScriptableObject
{
    public bool isStateFinished = false;
    public BaseState() { }
    public abstract void UpdateBehavior();


    [System.Serializable]
    public class PathWay
    {
        public GameObject pathHolder;
        public float timeToStay = 4;

    }



    public bool IsStateFinished()
    {
        return isStateFinished;
    }

    public void FinishState()
    {
        isStateFinished = true;
    }
    
}
