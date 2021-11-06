using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    private Action<Rocket> _killAction;
    Rocket instance;
    [SerializeField]
    float force;
    [SerializeField]
    GameObject impactParticlePrefab;

    [SerializeField]
    private int _damage;
    public int Damage { get { return _damage; } set { _damage = value; } }



    private void Awake()
    {
        instance = this;

    }


    private void Start()
    {
        if(instance.Type==RocketType.Dud)
        {
            
        }
    }


    public void Init(Action<Rocket> killaction)
    {
        _killAction = killaction;
    }
   public enum RocketType
    {
        Incendiary,
        Explosive,
        Dud


    }

    public RocketType Type;

   
   


  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Char"))

        {
            Instantiate(impactParticlePrefab, collision.collider.transform.position, Quaternion.identity);
            
            Debug.Log("Play Impact");
            var enemy = collision.transform.GetComponent<Enemy>();

            if(enemy)
            enemy.TakeDamage(_damage);

            var rb = collision.gameObject.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            //rb.AddExplosionForce(force, Vector3.up, 10);
            //rb.velocity = Vector3.up * force *10;
            Debug.Log("Blow character");

            gameObject.SetActive(false);

        }
    }

}
