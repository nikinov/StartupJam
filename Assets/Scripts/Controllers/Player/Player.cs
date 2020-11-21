using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [HideInInspector] public bool isCloseToButton;
    
    [SerializeField] private bool Player_1;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = .1f;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private float gravity = 9.81f;
    
    private CharacterController _controller;
    private float _turnSmoothVelocity;
    private float _directionY;
    private bool _isParented;
    private Vector3 _moveDirection = Vector3.zero;
    private Transform _parentDiference;
    private Vector3 lastPosition = Vector3.zero;
    
    public delegate void PressedAction();
    public event PressedAction OnPressed;

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal;
        float vertical;
        
        // Player1
        if (Player_1)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckGroundStatus();
            }

            if (Input.GetKeyDown(KeyCode.E) && isCloseToButton)
            {
                if (OnPressed != null)
                    OnPressed();
            }
        }
        
        // Player0
        else
        {
            horizontal = Input.GetAxisRaw("HorizontalArrow");
            vertical = Input.GetAxisRaw("VerticalArrow");
        }
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        // for all Players
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            _controller.Move(direction * speed * Time.deltaTime);
        }
        CheckForPlatform();
        Vector3 parentD = Vector3.zero;
        if (_isParented)
        {
            if(lastPosition != Vector3.zero)
                parentD = (_parentDiference.position - lastPosition)/Time.deltaTime;
            lastPosition = _parentDiference.position;
        }
        _moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move((_moveDirection + parentD) * Time.deltaTime);
    }
    void CheckGroundStatus()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit) == true)
        {
            if (transform.position.y - hit.point.y <= 1.5)
            {
                _moveDirection.y = jumpSpeed;
            }
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
    }
    void CheckForPlatform()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit) == true)
        {
            if (transform.position.y - hit.point.y <= 1.5 && hit.collider.gameObject.tag == "Platform")
            {
                if (!_isParented)
                {
                    _parentDiference = hit.collider.gameObject.transform;
                    _isParented = true;
                }
            }
            else
            {
                if (_isParented)
                {
                    _isParented = false;
                }
            }
        }
    }
}






















