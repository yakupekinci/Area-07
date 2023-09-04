using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private PlayerManager _playerManager;
    private Transform Player;
    public float speed = 1f;
    public float followDistance = 10f;
    private float cooldown = 2f;
    public GameObject mesh;
    public GameObject droneBullet;
    public GameObject destroyEffect;
    public AudioClip deathSound;
    public int DroneHP = 100;
    public float cooldownTime = 1f;
    private void Awake()
    {
        _gameUI = FindObjectOfType<GameUI>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        _playerManager = FindObjectOfType<PlayerManager>();
    }
    private void Update()
    {
        FollowPlayer();

        DroneDeath();
    }
    private void FollowPlayer()
    {
        transform.LookAt(Player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(0, 175, 0));
        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance >= followDistance && distance <= 40f && _playerManager.isAlive)

        {
            Shot();
            transform.Translate(transform.forward * Time.deltaTime * speed * -1);
        }
        else if (distance < 40f && _playerManager.isAlive)
        {
            Shot();
            transform.RotateAround(Player.position, transform.up, Time.deltaTime * speed * Random.Range(1f, 5f));

        }
    }

    private void Shot()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        else
        {
            cooldown = cooldownTime;
            mesh.GetComponent<Animator>().SetTrigger("isDroneShot");
            Instantiate(droneBullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 5F, 0)));

        }

    }
    private void DroneDeath()
    {
        if (DroneHP <= 0)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(deathSound);
            Destroy(this.gameObject);
            _gameUI.UpdateScore(50);
        }
    }

}

