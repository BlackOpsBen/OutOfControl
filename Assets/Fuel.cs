using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private float maxFuel = 1000f;
    private float fuel = 500f;
    private float rechargeRate = 100f;
    private float burnRate = 200f;

    private bool isRecharging = true;
    private bool isFull = false;

    private void Update()
    {
        if (isRecharging)
        {
            fuel += rechargeRate * Time.deltaTime;
            fuel = Mathf.Clamp(fuel, 0f, maxFuel);
        }

        if (fuel == maxFuel)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
    }

    public void BurnFuel()
    {
        fuel -= burnRate * Time.deltaTime;
        fuel = Mathf.Clamp(fuel, 0f, maxFuel);
    }

    public float GetCurrentFuel()
    {
        return fuel;
    }

    public void PauseRecharge()
    {
        isRecharging = false;
    }

    public void ResumeRecharge()
    {
        isRecharging = true;
    }

    public bool GetIsRecharging()
    {
        return isRecharging;
    }

    public bool GetIsFull()
    {
        return isFull;
    }
}
