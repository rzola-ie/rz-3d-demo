using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // moving
    [SerializeField] public CharacterController controller;
    [SerializeField] public float playerSpeed = 12f;

    // jumping
    [SerializeField] public float jumpHeight = 4f;
    [SerializeField] public float gravity = -9.81f;

    private Vector3 velocity;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public float groundDistance = 0.4f;
    [SerializeField] public LayerMask groundMask;
    private bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * playerSpeed * Time.deltaTime);


        // jump velocity = sqrt of height * -2 x gravity constant
        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
