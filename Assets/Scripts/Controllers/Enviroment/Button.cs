using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Platform platform;
    [SerializeField] private Player player;
    [SerializeField] private float distanceFromButton;
    [SerializeField] private GameObject indicatorTextUI;
    
    private bool _isCloseToPLayer;

    private void Start()
    {
        indicatorTextUI.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceFromButton)
        {
            if (!_isCloseToPLayer)
            {
                indicatorTextUI.SetActive(true);
                _isCloseToPLayer = true;
                player.isCloseToButton = true;
                player.OnPressed += ButtonPressed;
            }
        }
        else
        {
            if (_isCloseToPLayer)
            {
                indicatorTextUI.SetActive(false);
                _isCloseToPLayer = false;
                player.isCloseToButton = false;
                player.OnPressed -= ButtonPressed;
            }
            
        }
    }

    void ButtonPressed()
    {
        platform.MakeAction();
    }
}
