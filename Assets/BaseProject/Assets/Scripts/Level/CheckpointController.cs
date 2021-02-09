using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    private Checkpoint[] checkpoints;
    public Checkpoint currentCheckpoint;
    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this; 
        checkpoints = FindObjectsOfType<Checkpoint>();

        if (currentCheckpoint == null)
        {
            currentCheckpoint = checkpoints[0];
        }

        spawnPoint = currentCheckpoint.transform.position;
    }


    public void DeactivateCheckpoint()
    {
        for(int i =0; i< checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Checkpoint newSpawnPoint)
    {
        spawnPoint = newSpawnPoint.transform.position;
        currentCheckpoint = newSpawnPoint;
    }
}
