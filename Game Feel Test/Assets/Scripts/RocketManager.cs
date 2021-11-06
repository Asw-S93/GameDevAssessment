using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RocketManager : MonoBehaviour
{
    [SerializeField]
    List<Rocket> rocketPrefabs=new List<Rocket>();
    [SerializeField]
    Rocket prefab;
    [SerializeField]
    int activeRockets;
    [SerializeField]
    int totalRockets;
    ObjectPool<Rocket> rocketPool;
    [SerializeField]
    Transform silo1;
    [SerializeField]
    Transform silo2;
    [SerializeField]
    Transform silo3;

    [SerializeField]
    bool usePool=false;

    private void Start()
    {
       
       
        rocketPool = new ObjectPool<Rocket>
            (() =>
            {
                return Instantiate(prefab);
            }, actionOn =>
            {

                prefab.gameObject.SetActive(true);

            }, actionOff =>
            {
                prefab.gameObject.SetActive(false);
            },
            actionKill =>
            {
                Destroy(prefab.gameObject);
            },
            false, 10, 20);




        // InvokeRepeating( nameof(SpawnRockets),0.2f,0.2f);
        InvokeRepeating(nameof(Spawn), 0.2f, 0.2f);

    }


   void Spawn()
    {

        for(int i =0; i<totalRockets;i++)
        {
           

            foreach (Rocket m in rocketPrefabs)
            {
                if (activeRockets <= totalRockets) 

                {
                    activeRockets += 1;
                    if (m.Type == Rocket.RocketType.Dud)
                    {
                        var mis = Instantiate(m.gameObject, silo1);
                        mis.transform.position = silo1.position;
                    }
                }
            }
        }
    }


    private void SpawnRockets()
    {

        for (int i = 0; i < totalRockets; i++)
        {


            var missile = usePool ? rocketPool.Get() : Instantiate(prefab,transform);
            var missleType = missile.GetComponent<Rocket>();

            if (missleType.Type.Equals(Rocket.RocketType.Explosive))
            {
                missile.transform.SetParent(silo1);
                missile.transform.position = silo1.position;
                Debug.Log("Missle Pos1");
            }
            else if (missleType.Type.Equals(Rocket.RocketType.Explosive))
            {
                missile.transform.SetParent(silo2);
                missile.transform.position = silo2.position;
                Debug.Log("Missle Pos2");
            }
            else if (missleType.Type.Equals(Rocket.RocketType.Dud))
            {
                missile.transform.SetParent(silo3);
                missile.transform.position = silo3.position;
                Debug.Log("Missle Pos3");
            }

            //missleType.Init(KillRocket);
        }
    }
    
    //private void KillRocket(Rocket rocket)
    //{

    //    if (usePool) rocketPool.Release(rocket);
    //}

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
