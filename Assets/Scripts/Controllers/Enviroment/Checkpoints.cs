﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [HideInInspector] public Checkpoint CurrentCheckpointBlue;
    [HideInInspector] public Checkpoint CurrentCheckpointRed;
    [HideInInspector] public Checkpoint FinishCheckpointBlue;
    [HideInInspector] public Checkpoint FinishCheckpointRed;
    
    [SerializeField] private Player bluePlayer;
    [SerializeField] private Player redPlayer;
    private List<Checkpoint> checkpointListBlue;
    private List<Checkpoint> checkpointListRed;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        checkpointListBlue = new List<Checkpoint>();
        checkpointListRed = new List<Checkpoint>();
        
        foreach (Transform t in transform.GetChild(0))
        {
            checkpointListBlue.Add(t.GetComponent<Checkpoint>());
        }
        foreach (Transform t in transform.GetChild(1))
        {
            checkpointListRed.Add(t.GetComponent<Checkpoint>());
        }

        CurrentCheckpointBlue = checkpointListBlue[0];
        CurrentCheckpointRed = checkpointListRed[0];

        FinishCheckpointBlue = checkpointListBlue[checkpointListBlue.Count - 1];
        FinishCheckpointRed = checkpointListRed[checkpointListRed.Count - 1];
    }

    public void EnterNewCheckpointBlue(Checkpoint checkpoint)
    {
        bool isValidCheckpoint = false;
        foreach (Checkpoint checkpointt in checkpointListBlue)
        {
            if (checkpoint == checkpointt)
            {
                isValidCheckpoint = true;
            }
        }

        if (isValidCheckpoint)
        {
            if (checkpoint == checkpointListBlue[checkpointListBlue.Count - 1])
            {
                _gameManager.BluePlayerHasFinished();
            }
            else
            {
                CurrentCheckpointBlue = checkpoint;
                checkpoint.CheckpointEntered();
            }
        }
    }
    public void EnterNewCheckpointRed(Checkpoint checkpoint)
    {
        print("checkpointAAs");
        bool isValidCheckpoint = false;
        foreach (Checkpoint checkpointt in checkpointListRed)
        {
            print("checkpoints");
            if (checkpoint == checkpointt)
            {
                print("checkpoint found");
                isValidCheckpoint = true;
            }
        }

        if (isValidCheckpoint)
        {
            if (checkpoint == checkpointListRed[checkpointListRed.Count - 1])
            {
                _gameManager.RedPlayerHasFinished();
            }
            else
            {
                CurrentCheckpointRed = checkpoint;
                checkpoint.CheckpointEntered();
            }
        }
    }

    public void ResetSettings()
    {
        CurrentCheckpointBlue = checkpointListBlue[0];
        CurrentCheckpointRed = checkpointListRed[0];
    }
}
