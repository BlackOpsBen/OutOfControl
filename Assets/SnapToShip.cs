using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToShip : MonoBehaviour
{
    [SerializeField] private Transform ship;

    private void LateUpdate()
    {
        transform.position = ship.position;
    }
}
