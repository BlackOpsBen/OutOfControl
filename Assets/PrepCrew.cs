using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepCrew : MonoBehaviour
{
    private GetConfirmation getConfirmation;

    private IEnumerator outstandingAnnouncement;

    private void Awake()
    {
        getConfirmation = GetComponent<GetConfirmation>();
    }

    public void DeclareManeuver()
    {
        if (SelectManeuver.Instance.CheckForSelection())
        {
            outstandingAnnouncement = GetCrewConfirmation(SelectManeuver.Instance.GetSelectedManeuver());
            StartCoroutine(GetCrewConfirmation(SelectManeuver.Instance.GetSelectedManeuver()));
        }
        else
        {
            Debug.Log("You must make a maneuver selection before telling your crew your intentions.");
        }
    }

    private IEnumerator GetCrewConfirmation(int selectedManeuver)
    {
        DisableButtons.Instance.ToggleButtons(false);
        float delay;
        switch (SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name)
        {
            case "Turn Left":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayPrepareLeft();
                yield return new WaitForSeconds(delay);
                DisableButtons.Instance.ToggleButtons(true);
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            case "Turn Right":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayPrepareRight();
                yield return new WaitForSeconds(delay);
                DisableButtons.Instance.ToggleButtons(true);
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            case "Throttle Up":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayPrepareUp();
                yield return new WaitForSeconds(delay);
                DisableButtons.Instance.ToggleButtons(true);
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            case "Throttle Down":
                Debug.Log("Attention all crew. Prepare to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayPrepareDown();
                yield return new WaitForSeconds(delay);
                DisableButtons.Instance.ToggleButtons(true);
                getConfirmation.GetCrewResponse(selectedManeuver);
                break;
            default:
                Debug.LogError("Invalid string!");
                break;
        }
    }
}
