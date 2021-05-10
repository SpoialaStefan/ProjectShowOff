using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CustomNetworkManager networkManager=null;

    [Header("UI")]
    [SerializeField] private GameObject UI = null;
    [SerializeField] private Camera camera = null;

    public void StartClient()
    {
        networkManager.StartClient();
        UI.SetActive(false);
        camera.gameObject.SetActive(false);
    }
}
