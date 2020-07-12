using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHazard : MonoBehaviour
{
    [SerializeField] private GameObject indicatorPrefab;

    [SerializeField] private Hazard[] hazards;

    [SerializeField] private int maxEachPool = 10;

    private float timeSinceLastHazard = 0f;
    private float maxTimeBetweenHazards = 120f;

    private float rollInterval = 1f;
    private float rollTimer = 0f;

    private void Awake()
    {
        foreach (Hazard hazard in hazards)
        {
            hazard.objectPool = new GameObject[maxEachPool];
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CreateNewEvent();
        }

        rollTimer += Time.deltaTime;

        timeSinceLastHazard += Time.deltaTime;

        if (rollTimer > rollInterval)
        {
            rollTimer = 0f;
            float rand = UnityEngine.Random.Range(0f, maxTimeBetweenHazards);
            
            if (rand < timeSinceLastHazard)
            {
                timeSinceLastHazard = 0f;
                CreateNewEvent();
            }
        }

    }

    private void CreateNewEvent()
    {
        int rand = UnityEngine.Random.Range(0, hazards.Length);
        SpawnSelectedEvent(rand);
    }

    private void SpawnSelectedEvent(int hazard)
    {
        int lastPooled = hazards[hazard].lastPooled;
        if (hazards[hazard].objectPool[lastPooled] == null)
        {
            hazards[hazard].objectPool[lastPooled] = Instantiate(hazards[hazard].objectPrefab, transform.position, Quaternion.identity);
            GameObject indicator = Instantiate(indicatorPrefab, transform.position, Quaternion.identity);
            indicator.GetComponent<PointToHazard>().SetTarget(hazards[hazard].objectPool[lastPooled].transform);
        }
        else
        {
            hazards[hazard].objectPool[lastPooled].GetComponent<Spawn>().Respawn();
            if (hazards[hazard].name == "Asteroid")
            {
                hazards[hazard].objectPool[lastPooled].GetComponent<InitializeVector>().Reset();
            }
        }
        hazards[hazard].lastPooled++;
        if (hazards[hazard].lastPooled > maxEachPool-1)
        {
            hazards[hazard].lastPooled = 0;
        }
    }
}

[System.Serializable]
public class Hazard
{
    public string name;
    public GameObject objectPrefab;
    public GameObject[] objectPool;
    public int lastPooled = 0;
}