using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneuvers : MonoBehaviour
{
    private float currentSpeed = 0f;

    private float turnSpeed = 20f;

    private float acceleration = 20f;
    
    private float deceleration = 40f;

    private void Update()
    {
        transform.position = transform.position + transform.forward * currentSpeed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + currentSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ThrottleUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            ThrottleDown();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TurnLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnRight();
        }
    }

    public void ThrottleUp()
    {
        currentSpeed += acceleration * Time.deltaTime;
    }

    public void ThrottleDown()
    {
        currentSpeed -= deceleration * Time.deltaTime;
        currentSpeed = Mathf.Max(currentSpeed, 0f);
    }

    public void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y - turnSpeed * Time.deltaTime, transform.rotation.eulerAngles.z);
    }

    public void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + turnSpeed * Time.deltaTime, transform.rotation.eulerAngles.z);
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
