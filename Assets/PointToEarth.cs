using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToEarth : MonoBehaviour
{
    [SerializeField] private Transform earth;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation((earth.position - transform.position).normalized, Vector3.up);
    }
}
