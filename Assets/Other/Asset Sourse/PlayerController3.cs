using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController3 : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] Transform _checkGroundTransform;
    [SerializeField] LayerMask _groundMask;

    [Header("Settings")]
    [SerializeField] float _checkRadiusSphere = 0.2f;
    [SerializeField] float _gravity = -14f;
    [SerializeField] float _speed = 4f;
    [SerializeField] float _speedRun = 7f;
    [SerializeField] float _jumpHeight = 1f;
    [Range(1, 100)]
    [SerializeField] float _sensitivity = 50f;
    float rotationX;
    bool isGrounded;
    Vector3 velocity;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Velocity();
        Move();
        Rotate();
    }
    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);


        _cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up*mouseX);
    }
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        move = transform.forward * moveY + transform.right * moveX;

        if(Input.GetKey(KeyCode.LeftShift) && (moveX != 0 || moveY != 0))
        {
            _characterController.Move(move * _speedRun * Time.deltaTime);
        }
        else 
        {
            _characterController.Move(move * _speed * Time.deltaTime);
        }
    }
    private void Velocity()
    {
        isGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkRadiusSphere, _groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += Time.deltaTime * _gravity;
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
        _characterController.Move(velocity * Time.deltaTime);
    }
    void OnDrawGizmos()
    {
        
        if(isGrounded)
        {
            Gizmos.color = Color.green;
        Gizmos.DrawSphere(_checkGroundTransform.position, _checkRadiusSphere);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_checkGroundTransform.position, _checkRadiusSphere);
        }
        
    }

}
