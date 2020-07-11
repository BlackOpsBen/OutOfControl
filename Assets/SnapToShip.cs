using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToShip : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.position = Maneuvers.Instance.transform.position;
    }
}
