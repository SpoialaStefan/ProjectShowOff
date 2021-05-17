using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    [SerializeField]
    int minutes;
    [SerializeField]
    int seconds;

    float timer;

    private void Awake()
    {
        timer = minutes * 60 + seconds;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }
}
