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

    private bool _IsGamePaused = false;
    private bool _ESCpressed = false;
    private CanvasGroup _PauseMenuCanvasGroup;
    public Canvas PauseMenuCanvas;

    private Transform _originalTransformBlue;
    private Transform _originalTransformRed;
    private void Start()
    {
        StartCoroutine(showTarget());
        _PauseMenuCanvasGroup = PauseMenuCanvas.GetComponent<CanvasGroup>();

        _PauseMenuCanvasGroup.alpha = 0.0f;
        PauseMenuCanvas.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_ESCpressed)
            {
                if (_IsGamePaused)
                {
                    _IsGamePaused = false;
                    _PauseMenuCanvasGroup.alpha = 0.0f;
                    PauseMenuCanvas.enabled = false;
                    Time.timeScale = 1;
                }
                else
                {
                    _IsGamePaused = true;
                    _PauseMenuCanvasGroup.alpha = 1.0f;
                    PauseMenuCanvas.enabled = true;
                    Time.timeScale = 0;
                }
            }
            _ESCpressed = true;

        }
        else
        {
            _ESCpressed = false;
        }
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
