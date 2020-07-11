using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestPermission : MonoBehaviour
{
    private GetPermission getPermission;

    private void Awake()
    {
        getPermission = GetComponent<GetPermission>();
    }
    public void CallHouston()
    {
        if (SelectManeuver.Instance.CheckForSelection())
        {
            RequestManeuver(SelectManeuver.Instance.GetSelectedManeuver());
        }
        else
        {
            Debug.Log("You must make a maneuver selection before making contact with Houston.");
        }
    }

    private void RequestManeuver(int selectedManeuver)
    {
        switch (SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name)
        {
            // TODO probably don't need a case switch.
            case "Turn Left":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getPermission.ProcessRequest(selectedManeuver);
                break;
            case "Turn Right":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getPermission.ProcessRequest(selectedManeuver);
                break;
            case "Throttle Up":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getPermission.ProcessRequest(selectedManeuver);
                break;
            case "Throttle Down":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getPermission.ProcessRequest(selectedManeuver);
                break;
            default:
                Debug.LogError("Invalid string!");
                break;
        }
    }
}
