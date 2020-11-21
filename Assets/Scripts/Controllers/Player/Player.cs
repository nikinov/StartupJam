using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool Player_1;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = .1f;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private float gravity = 9.81f;
    
    private CharacterController _controller;
    private float _turnSmoothVelocity;
    private float _directionY;
    private bool m_IsGrounded;
    private float m_GroundCheckDistance;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal;
        float vertical;
        if (Player_1)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CheckGroundStatus();
            }
        }
        else
        {
            horizontal = Input.GetAxisRaw("HorizontalArrow");
            vertical = Input.GetAxisRaw("VerticalArrow");
        }
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            _controller.Move(direction * speed * Time.deltaTime);
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);
    }
    void CheckGroundStatus()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        //decalre a RaycastHit. This is neccessary so it can get "filled" with information when casting the ray below.
        RaycastHit hit;
        //cast the ray. Note the "out hit" which makes the Raycast "fill" the hit variable with information. The maximum distance the ray will go is 1.5
        if (Physics.Raycast(ray, out hit) == true)
        {
            if (transform.position.y - hit.point.y <= 1.5)
            {
                moveDirection.y = jumpSpeed;
            }
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
    }
}






















