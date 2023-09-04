using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    [SerializeField] private PlayerMovement _playerMovement;


    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //  Debug.Log("sill");
            _playerMovement.SpeedBoost();
            Destroy(gameObject);

        }

    }
}


