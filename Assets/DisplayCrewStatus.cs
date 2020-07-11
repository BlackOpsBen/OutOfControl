using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCrewStatus : MonoBehaviour
{
    [SerializeField] private GameObject crewStatusText;

    private void Update()
    {
        DisplayStatus(SelectManeuver.Instance.GetManeuvers()[SelectManeuver.Instance.GetSelectedManeuver()].crewConfirmed);
    }

    private void DisplayStatus(bool confirmed)
    {
        if (confirmed)
        {
            crewStatusText.SetActive(true);
        }
        else
        {
            crewStatusText.SetActive(false);
        }
    }
}
