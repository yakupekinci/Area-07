using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 rotateAxis;

    private void Awake()
    {
        speed = Random.Range(30, 70);
    }
    private void Update()
    {
        transform.Rotate(rotateAxis * speed * Time.deltaTime);
    }
}
