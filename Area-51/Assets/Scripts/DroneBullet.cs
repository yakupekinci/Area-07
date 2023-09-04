using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    public float speed = 100f;
    public float lifeTime = 5f;
    public bool droneBullet;
    public float bulletRadius = 2f;
    public LayerMask playerLayer;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -1);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        if (droneBullet)
        {
            if (Physics.CheckSphere(transform.position, bulletRadius, playerLayer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }
    }
}
