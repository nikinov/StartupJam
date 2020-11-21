using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class RobotRot : MonoBehaviour
{
    [SerializeField] private Transform BallToRotate;
    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        BallToRotate.transform.localEulerAngles = new Vector3(-transform.eulerAngles.x, -transform.eulerAngles.y, -transform.eulerAngles.z);
    }
}
