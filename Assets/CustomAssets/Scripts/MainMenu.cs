using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private GameObject UI = null;

    public void StartClient()
    {
        UI.SetActive(false);
    }
}
