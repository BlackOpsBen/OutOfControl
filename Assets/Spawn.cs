using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float minStartDist = 2000f;
    private float maxStartDist = 10000f;
    private Vector3 spawnPoint;

    public bool isEnabled = true;
    

    private void Awake()
    {
        if (isEnabled)
        {
            float heading = UnityEngine.Random.Range(0f, 360f);
            Quaternion startRotation = Quaternion.Euler(0f, heading, 0f);
            float randDistance = UnityEngine.Random.Range(minStartDist, maxStartDist);

            Vector3 spawnLocation = startRotation * Vector3.forward * randDistance;

            GoToSpawnPoint(spawnLocation);
        }
    }

    private void GoToSpawnPoint (Vector3 location)
    {
        transform.position = location;
    }
}
