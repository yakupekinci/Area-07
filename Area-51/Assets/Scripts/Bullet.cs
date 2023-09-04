using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float lifeTime = 5f;
    public GameObject hitEffect;


    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -1);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

       GameObject effect= Instantiate(hitEffect, transform.position, transform.rotation);
        effect.AddComponent<DestroyAny>();
        Destroy(this.gameObject);
    }
}
