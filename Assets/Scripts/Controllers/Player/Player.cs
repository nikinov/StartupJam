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
    
    private CharacterController _controller;
    private float _turnSmoothVelocity;

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
    }
}
