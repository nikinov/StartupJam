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
            if(Input.GetButtonDown("Jump") && _controller.isGrounded)
            {
                print("aa");
                transform.Translate(0, jumpSpeed * Time.deltaTime, 0);
            }
            else if (m_IsGrounded)
            {
                transform.Translate(0, - gravity * Time.deltaTime, 0);
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
        void CheckGroundStatus()
        {
            RaycastHit hitInfo;
#if UNITY_EDITOR
            // helper to visualise the ground check ray in the scene view
            Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
            // 0.1f is a small offset to start the ray from inside the character
            // it is also good to note that the transform position in the sample assets is at the base of the character
            if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
            {
                m_IsGrounded = true;
            }
            else
            {
                m_IsGrounded = false;
            }
        }
    }
}






















