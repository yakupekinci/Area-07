using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cones : MonoBehaviour
{

    public Vector3 velocity;
    private bool broke = false;
    private void Update()
    {

        if (broke)
        {
            velocity.y -= Time.deltaTime / 200;
            transform.Translate(velocity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            broke = true;
        }

    }
}