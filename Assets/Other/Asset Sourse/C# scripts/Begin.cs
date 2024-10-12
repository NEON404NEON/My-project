using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Begin : MonoBehaviour
{

    public float moveSpeed = 5.0f; //скорость
    private CharacterController controller;  // использование клидера
    


    
    void Start()
    {
        // скрывание курсора

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        // Билдинг клавишь WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //перемещение по (x) (y)  и (z) + плюс создание гравитации как способ перемещения но который не требует вмешательства
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.y -= 9.81f * Time.deltaTime;

        // создание онного движения + его плавности
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        //float sprintShift = Input.GetAxis("Shift");

       //if (sprintShift = true){(moveSpeed *= 2f);}
    }
}
