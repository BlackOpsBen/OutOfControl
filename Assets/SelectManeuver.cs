using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectManeuver : MonoBehaviour
{
    public static SelectManeuver Instance { get; private set; }

    [SerializeField] TextMeshProUGUI selectedManeuverLabel;

    private Maneuver[] maneuvers = new Maneuver[4];

    private int selectedManeuver;

    private bool isSelected = false;

    private void Awake()
    {
        SingletonPattern();
        InitializeManeuverList();
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

    private void InitializeManeuverList()
    {
        for (int i = 0; i < maneuvers.Length; i++)
        {
            maneuvers[i] = new Maneuver
            {
                allowed = false,
                denied = false,
                crewConfirmed = false
            };
        }

        maneuvers[0].name = "Turn Left";
        maneuvers[1].name = "Turn Right";
        maneuvers[2].name = "Throttle Up";
        maneuvers[3].name = "Throttle Down";
    }

    public void SetSelectedManeuver(int maneuver)
    {
        selectedManeuver = maneuver;
        isSelected = true;
        selectedManeuverLabel.text = maneuvers[maneuver].name;

        AudioManager.Instance.Play("Button");
    }

    public int GetSelectedManeuver()
    {
        return selectedManeuver;
    }

    public Maneuver[] GetManeuvers()
    {
        return maneuvers;
    }

    public bool CheckForSelection()
    {
        return isSelected;
    }

    public void SetAllowedManeuver(int allowedManeuver)
    {
        for (int i = 0; i < maneuvers.Length; i++)
        {
            if (i == allowedManeuver)
            {
                maneuvers[i].allowed = true;
                maneuvers[i].denied = false;
            }
            else
            {
                maneuvers[i].allowed = false;
                maneuvers[i].denied = false;
            }
        }
    }

    public void SetDeniedManeuver(int deniedManeuver)
    {
        for (int i = 0; i < maneuvers.Length; i++)
        {
            if (i == deniedManeuver)
            {
                maneuvers[i].allowed = false;
                maneuvers[i].denied = true;
            }
            else
            {
                maneuvers[i].denied = false;
            }
        }
    }

    public void SetConfirmedManeuver(int confirmedManeuver)
    {
        for (int i = 0; i < maneuvers.Length; i++)
        {
            if (i == confirmedManeuver)
            {
                maneuvers[i].crewConfirmed = true;
            }
            else
            {
                maneuvers[i].crewConfirmed = false;
            }
        }
    }

    public void CompleteManeuver()
    {
        ResetStatuses();
    }

    private void ResetStatuses()
    {
        for (int i = 0; i < maneuvers.Length; i++)
        {
            maneuvers[i].allowed = false;
            maneuvers[i].denied = false;
            maneuvers[i].crewConfirmed = false;
        }
    }
}

public struct Maneuver
{
    public string name;
    public bool allowed;
    public bool denied;
    public bool crewConfirmed;
}
