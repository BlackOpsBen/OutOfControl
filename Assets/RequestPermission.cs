using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestPermission : MonoBehaviour
{
    private GetPermission getPermission;

    private IEnumerator outstandingRequest;

    private void Awake()
    {
        getPermission = GetComponent<GetPermission>();
    }
    public void CallHouston()
    {
        if (SelectManeuver.Instance.CheckForSelection())
        {
            outstandingRequest = RequestManeuver(SelectManeuver.Instance.GetSelectedManeuver());
            StartCoroutine(outstandingRequest);
        }
        else
        {
            Debug.Log("You must make a maneuver selection before making contact with Houston.");
        }

        AudioManager.Instance.Play("Comms");
    }

    private IEnumerator RequestManeuver(int selectedManeuver)
    {
        DisableButtons.Instance.ToggleButtons(false);
        float delay;
        switch (SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name)
        {
            case "Turn Left":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayRequestLeft();
                yield return new WaitForSeconds(delay);
                getPermission.ProcessRequest(selectedManeuver);
                break;
            case "Turn Right":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayRequestRight();
                yield return new WaitForSeconds(delay);
                getPermission.ProcessRequest(selectedManeuver);
                break;
            case "Throttle Up":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayRequestUp();
                yield return new WaitForSeconds(delay);
                getPermission.ProcessRequest(selectedManeuver);
                break;
            case "Throttle Down":
                Debug.Log("Ship to Houston, requesting permission to " + SelectManeuver.Instance.GetManeuvers()[selectedManeuver].name + ".");
                delay = AudioManager.Instance.PlayRequestDown();
                yield return new WaitForSeconds(delay);
                getPermission.ProcessRequest(selectedManeuver);
                break;
            default:
                Debug.LogError("Invalid string!");
                break;
        }
    }
}
