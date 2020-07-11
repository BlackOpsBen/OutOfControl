using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetConfirmation : MonoBehaviour
{
    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 5f;

    private IEnumerator pendingResponse;

    public void GetCrewResponse(int declaredManeuver)
    {
        pendingResponse = GetDelayedResponse(declaredManeuver);
        StartCoroutine(pendingResponse);

    }

    private IEnumerator GetDelayedResponse(int declaredManeuver)
    {
        float randDelay = UnityEngine.Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(randDelay);
        SelectManeuver.Instance.SetConfirmedManeuver(declaredManeuver);
        PlayVerbalResponse();
    }

    private void PlayVerbalResponse()
    {
        Debug.Log("Copy that. Prepared to " + SelectManeuver.Instance.GetManeuvers()[SelectManeuver.Instance.GetSelectedManeuver()] + ".");
        AudioManager.Instance.PlayConfirmed();
    }

    public void CancelGetResponse()
    {
        if (pendingResponse != null)
        {
            StopCoroutine(pendingResponse);
        }
    }
}
