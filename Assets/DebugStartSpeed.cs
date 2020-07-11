using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStartSpeed : MonoBehaviour
{
    private Maneuvers maneuvers;
    [SerializeField] private float startSpeed = 100;

    private void Awake()
    {
        maneuvers = FindObjectOfType<Maneuvers>();
        maneuvers.DebugSetSpeed(startSpeed);
    }
}
