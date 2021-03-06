﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPermission : MonoBehaviour
{
    private float threshold = 0.1f;
    private float moodChange = 0.1f;

    public void ProcessRequest(int request)
    {
        bool decision = MakeDecision();

        if (decision)
        {
            AllowManeuver(request);
        }
        else
        {
            DenyManeuver(request);
        }
    }

    private bool MakeDecision()
    {
        float rand = UnityEngine.Random.Range(0f, 1f);

        if (rand > threshold)
        {
            threshold = Mathf.Clamp(threshold + moodChange, 0f, 1f);
            return true;
        }
        else
        {
            threshold = Mathf.Clamp(threshold - moodChange, 0f, 1f);
            return false;
        }
    }

    private void AllowManeuver(int maneuver)
    {
        float delay;
        Debug.Log("Roger that, Splorer One. Permission granted. Proceed to " + SelectManeuver.Instance.GetManeuvers()[maneuver].name + ".");

        delay = AudioManager.Instance.PlayGranted(); // TODO utilize delay.


        DisableButtons.Instance.ToggleButtons(true);

        SelectManeuver.Instance.SetAllowedManeuver(maneuver);
    }

    private void DenyManeuver(int maneuver)
    {
        float delay;
        Debug.Log("Negative, Splorer One. Do not " + SelectManeuver.Instance.GetManeuvers()[maneuver].name + ". Repeat, do not " + SelectManeuver.Instance.GetManeuvers()[maneuver].name + "."); ;

        delay = AudioManager.Instance.PlayDenied(); // TODO utilize delay.


        DisableButtons.Instance.ToggleButtons(true);

        SelectManeuver.Instance.SetDeniedManeuver(maneuver);
    }
}
