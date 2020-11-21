using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Platform platform;
    [SerializeField] private Player player;
    [SerializeField] private float distanceFromButton;
    
    private bool _isCloseToPLayer;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceFromButton)
        {
            if (!_isCloseToPLayer)
            {
                _isCloseToPLayer = true;
                player.isCloseToButton = true;
                player.OnPressed += ButtonPressed;
            }
        }
        else
        {
            if (_isCloseToPLayer)
            {
                _isCloseToPLayer = false;
                player.isCloseToButton = false;
                player.OnPressed -= ButtonPressed;
            }
            
        }
    }

    void ButtonPressed()
    {
        print("button pressed");
        platform.MakeAction();
    }
}
