﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneuvers : MonoBehaviour
{
    public static Maneuvers Instance { get; private set; }

    private float currentSpeed = 0f;

    private float turnSpeed = 20f;

    private float acceleration = 20f;
    
    private float deceleration = 40f;

    private bool isExecuting = false;

    private Fuel fuel;

    private TurnKey key;

    private ManeuverPFX maneuverPFX;

    private StrikeSystem strikeSystem;

    private bool alreadyChecked;

    private void Awake()
    {
        SingletonPattern();

        fuel = GetComponent<Fuel>();

        maneuverPFX = GetComponent<ManeuverPFX>();

        strikeSystem = FindObjectOfType<StrikeSystem>();
    }

    private void Start()
    {
        key = SelectManeuver.Instance.GetComponent<TurnKey>();
    }

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        transform.position = transform.position + transform.forward * currentSpeed * Time.deltaTime;

        if (isExecuting)
        {
            Execute();
        }

        //DebugginInputs();
    }

    //private void DebugginInputs()
    //{
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        ThrottleUp();
    //    }

    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        ThrottleDown();
    //    }

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        TurnLeft();
    //    }

    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        TurnRight();
    //    }
    //}

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

    private void Execute()
    {
        bool isStopping = false;

        if (fuel.GetCurrentFuel() > 0f)
        {
            fuel.PauseRecharge();

            string selectedManeuver = SelectManeuver.Instance.GetManeuvers()[SelectManeuver.Instance.GetSelectedManeuver()].name;

            switch (selectedManeuver)
            {
                case "Turn Left":
                    TurnLeft();
                    break;
                case "Turn Right":
                    TurnRight();
                    break;
                case "Throttle Up":
                    ThrottleUp();
                    break;
                case "Throttle Down":
                    ThrottleDown();
                    isStopping = true;
                    break;
                default:
                    Debug.LogError("Invalid string!");
                    break;
            }

            fuel.BurnFuel();
            maneuverPFX.SetPFXPlaying(selectedManeuver, true);

            if (!alreadyChecked)
            {
                alreadyChecked = true;
                CheckForValidManeuver(selectedManeuver);
            }
        }
        else
        {
            EndExecute();
        }

        if (isStopping && currentSpeed < float.Epsilon)
        {
            EndExecute();
        }
    }

    public void StartExecute()
    {
        isExecuting = true;
        AudioManager.Instance.Play("Execute");
        AudioManager.Instance.PlayLoop("Thrusters");
    }

    public void EndExecute()
    {
        isExecuting = false;
        SelectManeuver.Instance.CompleteManeuver();
        key.SetKeyTurn();
        fuel.ResumeRecharge();
        maneuverPFX.SetPFXPlaying(false);
        Debug.Log("Called Stop on PFX");
        alreadyChecked = false;

        AudioManager.Instance.StopLoop("Thrusters");
    }

    public void DebugSetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void CheckForValidManeuver(string executedManeuver)
    {
        if (SelectManeuver.Instance.isManeuverValid(executedManeuver))
        {
            Debug.Log("Maneuver is valid.");
        }
        else
        {
            strikeSystem.GainStrike();
        }
    }
}
