using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCameraBlue;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCameraRed;
    [SerializeField] private Checkpoints checkpoints;
    private Transform _originalTransformBlue;
    private Transform _originalTransformRed;
    private void Start()
    {
        StartCoroutine(showTarget());
    }

    public void BluePlayerHasFinished()
    {
        
    }
    
    public void RedPlayerHasFinished()
    {
        
    }

    IEnumerator showTarget()
    {
        cinemachineVirtualCameraBlue.GetCinemachineComponent<CinemachineHardLockToTarget>().m_Damping = 1;
        cinemachineVirtualCameraRed.GetCinemachineComponent<CinemachineHardLockToTarget>().m_Damping = 1;
        _originalTransformBlue = cinemachineVirtualCameraBlue.Follow;
        _originalTransformRed = cinemachineVirtualCameraRed.Follow;
        yield return new WaitForSeconds(.5f);
        cinemachineVirtualCameraBlue.Follow = checkpoints.FinishCheckpointBlue.transform;
        cinemachineVirtualCameraRed.Follow = checkpoints.FinishCheckpointRed.transform;
        yield return new WaitForSeconds(2);
        cinemachineVirtualCameraBlue.Follow = _originalTransformBlue;
        cinemachineVirtualCameraRed.Follow = _originalTransformRed;
        cinemachineVirtualCameraBlue.GetCinemachineComponent<CinemachineHardLockToTarget>().m_Damping = 3;
        cinemachineVirtualCameraRed.GetCinemachineComponent<CinemachineHardLockToTarget>().m_Damping = 3;
    }
}
