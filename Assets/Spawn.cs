using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float minStartDist = 49f;
    [SerializeField] private float maxStartDist = 50f;

    [SerializeField] private float minHeading = 0f;
    [SerializeField] private float maxHeading = 360f;

    public bool isEnabled = true;
    

    private void Awake()
    {
        if (isEnabled)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        float heading = UnityEngine.Random.Range(minHeading, maxHeading);
        Quaternion startRotation = Quaternion.Euler(0f, heading, 0f);
        float randDistance = UnityEngine.Random.Range(minStartDist, maxStartDist);

        Vector3 spawnLocation = startRotation * Vector3.forward * randDistance;

        GoToSpawnPoint(spawnLocation);
    }

    private void GoToSpawnPoint (Vector3 location)
    {
        if (gameObject.CompareTag("Player"))
        {
            transform.position = location;
        }
        else
        {
            transform.position = location + Maneuvers.Instance.transform.position;
        }
    }
}
