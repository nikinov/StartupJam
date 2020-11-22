using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> whenEntered;

    private void Start()
    {
        foreach (GameObject t in whenEntered)
        {
            t.SetActive(false);
        }
    }

    public void CheckpointEntered()
    {
        foreach (GameObject t in whenEntered)
        {
            t.SetActive(true);
        }
    }

}
