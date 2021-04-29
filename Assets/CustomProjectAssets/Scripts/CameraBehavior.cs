using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CameraBehavior : NetworkBehaviour
{
    [SerializeField]
    private Transform _cameraObject;

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        _cameraObject.gameObject.SetActive(true);
    }
}
