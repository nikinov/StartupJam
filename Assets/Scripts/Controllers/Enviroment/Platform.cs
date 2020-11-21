using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform endPossition;
    [SerializeField] private Transform startingPossition;

    [SerializeField] private  float moveSpeed = 5;

    private Transform target;
    private bool isMoving;
    private void Start()
    {
        isMoving = false;
        target = startingPossition;
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Vector3.Distance(transform.position, target.position) >= .5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
            }
            else
            {
                transform.position = target.position;
                isMoving = false;
            }
        }
    }

    public void MakeAction()
    {
        if (target == endPossition)
        {
            target = startingPossition;
        }
        else
        {
            target = endPossition;
        }
        isMoving = true;
    }
}
