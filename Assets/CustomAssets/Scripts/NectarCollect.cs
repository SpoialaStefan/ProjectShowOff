using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarCollect : MonoBehaviour
{

    int nectarAmount = 0;


    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (other.GetComponent<NectarDistributor>())
            {
                nectarAmount += other.GetComponent<NectarDistributor>().nectarAmount;
                Debug.Log("Nectar collected, total amount: " + nectarAmount);
                Destroy(other.gameObject);
            }
        }
    }
}
