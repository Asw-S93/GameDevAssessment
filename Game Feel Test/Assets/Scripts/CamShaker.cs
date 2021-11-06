using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaker : MonoBehaviour
{

    CinemachineImpulseSource source;
    Rocket rocket;

    [SerializeField]
    float ImpactForce;
   

    private void Awake()
    {
        source = GetComponent<CinemachineImpulseSource>();
        rocket= GetComponent<Rocket>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.CompareTag("Char"))
        {
           
            if (rocket.Type == Rocket.RocketType.Explosive)
            {
                Debug.Log("Shake");
                source.GenerateImpulse(ImpactForce);
            }
            else if (rocket.Type == Rocket.RocketType.Dud)
            {
                Debug.Log("Shake");
                source.GenerateImpulse(ImpactForce);
            }
            else if (rocket.Type == Rocket.RocketType.Incendiary)
            {
                Debug.Log("Shake");
                source.GenerateImpulse(ImpactForce);
            }

        }


    }


}
