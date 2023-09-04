using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject deathEffect;
    public GameObject spawnPoint;
    public GameObject deathEffectPoint;
    public bool isAlive = true;
    private int num = 5;
    int i = 0;
    [SerializeField] private int health = 3;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private WeaponController _WeaponController;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            i++;
            if (i % 2 != 0)
            {
                GameOver();
            }
            else
            {
                DeaActiveGameOver();
            }

        }
    }
    public void Death()
    {
        if (isAlive)
        {
            health -= 1;
            isAlive = false;
            if (health > 0)
            {
                StartCoroutine(Dead());
            }
            if (health == 0)
            {
                GameOver();
            }
        }
    }

    private IEnumerator Dead()
    {
        if (spawnPoint != null)
        {
            StartCoroutine(DeadRestart());
            yield return new WaitForSeconds(4f);
            Restart();
        }
        else
        {
            Debug.LogError("spawnPoint is not assigned in PlayerManager!");
        }
        isAlive = true;
    }


    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CameraController>().enabled = false;
        _gameUI.pauseMenu.SetActive(true);
        _gameUI.inGameUI.SetActive(false);
        _WeaponController.hand.gameObject.SetActive(false);
        _WeaponController.crosshair.SetActive(false);
    }
    public void DeaActiveGameOver()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<CameraController>().enabled = true;
        _gameUI.pauseMenu.SetActive(false);
        _gameUI.inGameUI.SetActive(false);
        _WeaponController.hand.gameObject.SetActive(true);
        _WeaponController.crosshair.SetActive(true);
    }
    public IEnumerator DeadRestart()
    {
        transform.position = spawnPoint.transform.position;
        Instantiate(deathEffect, deathEffectPoint.transform.position, Quaternion.identity);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CameraController>().enabled = false;
        _WeaponController.hand.gameObject.SetActive(false);
        _gameUI.StartCoroutine(_gameUI.HpBars());
        yield return new WaitForSeconds(2f);
        _gameUI.restartMenu.SetActive(true);
        _gameUI.inGameUI.SetActive(false);
        StartCoroutine(RestartTime());
    }
    public void Restart()
    {
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<CameraController>().enabled = true;
        _gameUI.restartMenu.SetActive(false);
        _WeaponController.hand.gameObject.SetActive(true);
        _WeaponController.crosshair.SetActive(true);
        _gameUI.inGameUI.SetActive(true);
        transform.rotation = new Quaternion(0, 0, 0, 1);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public IEnumerator RestartTime()
    {
        for (int i = 3; i > 0; i--)
        {
            _gameUI.restartTimeText.text = "" + i;
            yield return new WaitForSeconds(0.5f);
            if (i == 1)
            {
                _gameUI.restartTimeText.text = "GO !!";
            }
        }


    }
}