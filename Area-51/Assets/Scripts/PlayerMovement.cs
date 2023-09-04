using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private SpeedSlider _speedSlider;
    private CharacterController controller;
    public float speed = 1f;
    public float newSpeed = 1f;

    //Jump & Gravity
    private Vector3 velocity;
    private float gravity = -9.8f;
    public float groundCheckRadius;
    public Transform checkGround;
    public LayerMask obstacleLayer;
    private bool isGround;

    public float jumpHeight = 0.5f;
    public float gravityDevide = 100f;
    public float jumpSpeed = 100f;
    private float aTimer;

    private float nextJumpTime;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        _playerManager = GetComponent<PlayerManager>();
        _speedSlider = FindObjectOfType<SpeedSlider>();
    }
    void Update()
    {
        if (_playerManager.isAlive)
        {
            //Check character is grounded

            isGround = Physics.CheckSphere(checkGround.position, groundCheckRadius, obstacleLayer);
            //Movement

            Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
            Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
            controller.Move(moveVelocity);
            //Gravity
            if (!isGround)
            {
                velocity.y += gravity * Time.deltaTime / gravityDevide;
                aTimer += Time.deltaTime / 3;
                speed = Mathf.Lerp(10, jumpSpeed, aTimer);
            }
            else
            {
                velocity.y = -0.05f;
                speed = newSpeed;
                aTimer = 0;
            }
            //Jump
            if (Input.GetAxis("Jump") > 0 && isGround && Time.time >= nextJumpTime)
            {
                nextJumpTime = Time.time + 0.1f;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDevide);
            }
            controller.Move(velocity);
        }
    }
    public IEnumerator SpeedBoostE(int i)
    {
        newSpeed += 2.5f;
        jumpSpeed += 2.5f;
        jumpHeight += 0.01f;
        _speedSlider.ActiveSlider();
        yield return new WaitForSeconds(i);
        _speedSlider.DeActiveSlider();
        speed -= 2.5f;
        jumpSpeed -= 2.5f;
        jumpHeight -= 0.01f; ;
    }
    public void SpeedBoost()
    {
        StartCoroutine(SpeedBoostE(30));
    }

}
