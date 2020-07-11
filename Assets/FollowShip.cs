using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    [SerializeField] private Transform ship;
    [SerializeField] private float smoothing = 10f;

    private void LateUpdate()
    {
        transform.position = ship.position;
        //transform.position = Vector3.Lerp(transform.position, ship.position, Time.deltaTime * smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, ship.rotation, Time.deltaTime * smoothing);
    }
}
