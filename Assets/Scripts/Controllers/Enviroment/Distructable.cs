using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using UnityEngine;

public class Distructable : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject BreakVersion;
    [SerializeField] private float bForce;
    [SerializeField] private float distanceFromDestruction = 5;
    private int active;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceFromDestruction)
        {
            player.OnDestroy += Destroy;
        }
        else
        {
            player.OnDestroy -= Destroy;
        }
    }

    private void Destroy()
    {
        active+=1;
        GameObject go = Instantiate(BreakVersion, transform.position, transform.rotation, gameObject.transform.parent);
        //go.GetComponent<Rigidbody>().AddExplosionForce(10f, Vector3.zero, 0f);
        Destroy(gameObject);
    }
    
}
