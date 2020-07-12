using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseProtocols : MonoBehaviour
{
    [SerializeField] private float xPos;

    private float openXPos = -28f;
    private float closedXPos = -37f;

    [SerializeField] private bool isOpen = false;

    private float speed = 10f;

    private void Awake()
    {
        xPos = transform.position.x;
    }

    //private void Update()
    //{
    //    transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    //}

    private void Update()
    {
        float desiredXPos;
        if (isOpen)
        {
            desiredXPos = openXPos;
        }
        else
        {
            desiredXPos = closedXPos;
        }

        Vector3 desiredPos = new Vector3(desiredXPos, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);     
    }

    public void ToggleViewProtocols(bool value)
    {
        isOpen = value;
    }
}
