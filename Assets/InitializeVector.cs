using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeVector : MonoBehaviour
{
    private Vector3 directionToShip;

    private Vector3 vectorToShip;
    private Vector3 shipVector;
    private Vector3 componentVector;

    private float speed = 0.075f;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        SetSpeed();

        SetVector();
    }

    private void SetSpeed()
    {
        speed = speed * Random.Range(0.5f, 1f);
    }

    private void SetVector()
    {
        vectorToShip = Maneuvers.Instance.transform.position - transform.position;
        shipVector = Maneuvers.Instance.transform.forward * Maneuvers.Instance.GetCurrentSpeed() / speed;
        componentVector = shipVector + vectorToShip;
    }

    private void LateUpdate()
    {
        transform.position = transform.position + componentVector * Time.deltaTime * speed;
    }
}
