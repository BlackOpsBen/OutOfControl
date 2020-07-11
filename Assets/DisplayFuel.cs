using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFuel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private GameObject ship;
    [SerializeField] Color fullColor;
    [SerializeField] Color burnColor;
    [SerializeField] Color rechargeColor;

    private Fuel fuel;

    private void Awake()
    {
        fuel = ship.GetComponent<Fuel>();
    }

    private void Update()
    {
        fuelText.text = Mathf.RoundToInt(fuel.GetCurrentFuel()).ToString();

        if (fuel.GetIsFull())
        {
            fuelText.color = fullColor;
        }
        else if (fuel.GetIsRecharging())
        {
            fuelText.color = rechargeColor;
        }
        else
        {
            fuelText.color = burnColor;
        }
    }
}
