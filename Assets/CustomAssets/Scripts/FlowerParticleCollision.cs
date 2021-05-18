using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerParticleCollision : MonoBehaviour
{

    public Material TestMaterial;
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Pesticide")
        {
            // EventQueue.eventQueue.AddEvent(new PlayerPesticideCollisionEventData());
            GetComponent<Renderer>().material = TestMaterial;
        }
    }

}
