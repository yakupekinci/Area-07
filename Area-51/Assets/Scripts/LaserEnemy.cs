using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle, playerLayer;
    public Transform laserPos;
    public float laserMulpiler = 1f;
    private bool laserHit;
    public float range=100f;

    LineRenderer lineR;
    private void Awake()
    {
        lineR = GetComponent<LineRenderer>();
    }

    private void Update()
    {

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacle))
        {
            lineR.enabled = true;
            laserHit = true;
            lineR.SetPosition(0, laserPos.transform.position);
            lineR.SetPosition(1, hit.point);
            lineR.startWidth = 0.050f * laserMulpiler + Mathf.Sin(Time.time) / 50;
        }
        else
        {
            lineR.enabled = false;
            laserHit = false;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, playerLayer))
        {
            if (laserHit)
            {   
                hit.transform.GetComponent<PlayerManager>().Death();
            }
        }

    }
}
