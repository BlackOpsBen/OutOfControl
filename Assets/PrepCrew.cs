using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepCrew : MonoBehaviour
{
    private GetConfirmation getConfirmation;

    private void Awake()
    {
        getConfirmation = GetComponent<GetConfirmation>();
    }

    public void DeclareManeuver()
    {
        if (SelectManeuver.Instance.CheckForSelection())
        {
            GetCrewConfirmation(SelectManeuver.Instance.GetSelectedManeuver());
        }
        else
        {
            Debug.Log("You must make a maneuver selection before telling your crew your intentions.");
        }
    }

    private void GetCrewConfirmation(int selectedManeuver)
    {
        switch (SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name)
        {
            // TODO probably don't need a case switch.
            // Also, this seems very familiar to RequestPermission
            case "Turn Left":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            case "Turn Right":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            case "Throttle Up":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            case "Throttle Down":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            default:
                Debug.LogError("Invalid string!");
                break;
        }
    }
}
