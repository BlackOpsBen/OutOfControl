using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayApprovalStatus : MonoBehaviour
{
    [SerializeField] private GameObject grantedText;
    [SerializeField] private GameObject deniedText;

    private void Update()
    {
        DisplayStatus(SelectManeuver.Instance.GetManeuvers()[SelectManeuver.Instance.GetSelectedManeuver()].allowed, SelectManeuver.Instance.GetManeuvers()[SelectManeuver.Instance.GetSelectedManeuver()].denied);
    }

    public void DisplayStatus(bool allowed, bool denied)
    {
        if (allowed)
        {
            deniedText.SetActive(false);
            grantedText.SetActive(true);
        }
        else if (denied)
        {
            grantedText.SetActive(false);
            deniedText.SetActive(true);
        }
        else
        {
            grantedText.SetActive(false);
            deniedText.SetActive(false);
        }
    }
}
