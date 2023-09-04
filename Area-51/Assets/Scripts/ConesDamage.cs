using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConesDamage : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<PlayerManager>().Death();
        }

    }


}
