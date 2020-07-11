using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeVector : MonoBehaviour
{
    private Maneuvers ship;

    private Vector3 directionToShip;

    private Vector3 vectorToShip;
    private Vector3 shipVector;
    private Vector3 componentVector;

    private float speed = .5f;

    private void Awake()
    {
        ship = FindObjectOfType<Maneuvers>();
    }

    private void Start()
    {
        vectorToShip = ship.transform.position - transform.position;
        shipVector = ship.transform.forward * ship.GetCurrentSpeed() / speed;
        componentVector = shipVector + vectorToShip;
    }

    private void Update()
    {
        transform.position = transform.position + componentVector * Time.deltaTime * speed;
    }
}
