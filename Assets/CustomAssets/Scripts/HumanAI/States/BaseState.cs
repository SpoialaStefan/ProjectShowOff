using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

using UnityEditor;

#endif
public abstract class BaseState : MonoBehaviour
{
    public bool isStateFinished = false;
    public HumanStates state;
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
