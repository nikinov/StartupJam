using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [HideInInspector] public Checkpoint CurrentCheckpointBlue;
    [HideInInspector] public Checkpoint CurrentCheckpointRed;
    
    [SerializeField] private Player bluePlayer;
    [SerializeField] private Player redPlayer;
    private List<Checkpoint> checkpointListBlue;
    private List<Checkpoint> checkpointListRed;

    private void Start()
    {
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
            CurrentCheckpointBlue = checkpoint;
        }
    }
    public void EnterNewCheckpointRed(Checkpoint checkpoint)
    {
        bool isValidCheckpoint = false;
        foreach (Checkpoint checkpointt in checkpointListRed)
        {
            if (checkpoint == checkpointt)
            {
                isValidCheckpoint = true;
            }
        }

        if (isValidCheckpoint)
        {
            CurrentCheckpointRed = checkpoint;
        }
    }

    public void ResetSettings()
    {
        CurrentCheckpointBlue = checkpointListBlue[0];
        CurrentCheckpointRed = checkpointListRed[0];
    }
}
