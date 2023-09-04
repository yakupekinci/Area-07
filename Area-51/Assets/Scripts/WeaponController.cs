using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacleLayer;
    public Vector3 offset;
    public GameObject bullet;
    public GameObject crosshair;
    public Transform firePoint;

    private float coolDown;
    public AudioClip gunShot;
    Animator anim;
    public Transform hand;

    private void Awake()
    {
        anim = GetComponent<Animator>();


    }
    private void Update()
    {
        //Look
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);
        }

        //Fire
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDown <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(90, 0, 180));
            coolDown = 0.25f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot);
            anim.SetTrigger("shot");
        }
    }
}
