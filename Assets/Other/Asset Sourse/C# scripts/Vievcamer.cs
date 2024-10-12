using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vievcamer : MonoBehaviour
{
    // Алгоритм вращения камерой тут ничего сложного просто используються
    // клавиши и их дальнейший билдинг в коде позволит вращать камерой


    // Создание /сенсы
    public float sensitivity = 2.0f;
    public float maxYAngle = 80.0f;
    private float rotationX = 0.0f;

    void Update()
    {
        // Создание переменных со значением нажатия кнопок 
        // (тоесть увода миши вверх и вниз соответственно)
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Создание вращения камерой
        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);

        // Инвертация одной из осей мы же не вертолётом управляем 
        rotationX -= mouseY * sensitivity;


        // Плавность и сила вращения с помощью формулы
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
