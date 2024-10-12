using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
//using System.Runtime.Intrinsics.X86;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Это рабочий код передвижения с функцией прыжка и приседания
    
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float jumpHeight = 3f;
    public float speed = 5f;
    public float speedBoost = 0;
    public float gravity = -9.0f;
    public float groundDistance = 0.4f;
    Vector3 velocity;

    bool isGrounded;

    void Start()
    {
        // скрывание курсора

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        


        Vector3 move = transform.right * x + transform.forward*z;
        controller.Move(move*speed*Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey("c"))
        {
            controller.height = 1f;

        } else
        {
            controller.height = 2f;
        }


        // Создаю спринт при зажатом Shift будет увеличиваться скорость
        /*
        if (Input.GetKey("shift"))
        {
            speedBoost += 10f;
            speed = speed + speedBoost;
            speedBoost = 

        }
        else
        {
            
        }*/
    }
}
