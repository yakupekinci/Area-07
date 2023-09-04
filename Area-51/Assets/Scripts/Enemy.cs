using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AudioClip hitSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(hitSound);
            gameObject.GetComponent<DroneAI>().DroneHP -= 25;
        }
    }
}
