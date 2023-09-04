using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSens = 100f;
    private float xRotation = 0f;
    private void Awake()
    {
        //cursor
        transform.Rotate(0, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        //Camera look
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        xRotation = Math.Clamp(xRotation, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
