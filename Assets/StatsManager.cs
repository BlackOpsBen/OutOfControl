using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    [Header("Bodies")]
    [SerializeField] private Transform ship;
    [SerializeField] private Transform earth;
    [Header("Data Fields")]
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI dist;

    private Maneuvers maneuvers;

    private void Awake()
    {
        maneuvers = ship.GetComponent<Maneuvers>();
    }

    private void Update()
    {
        speed.text = (Mathf.RoundToInt(maneuvers.GetCurrentSpeed()) * 10).ToString();

        dist.text = (Mathf.RoundToInt(Vector3.Distance(ship.position, earth.position)) * 10).ToString();
    }
}
