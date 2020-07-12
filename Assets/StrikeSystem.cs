using UnityEngine;
using TMPro;

public class StrikeSystem : MonoBehaviour
{
    private const int maxStrikes = 3;
    private int currentStrikes = 0;

    [SerializeField] private TextMeshProUGUI strikesText;

    private void Awake()
    {
        strikesText.text = "";
    }

    public void GainStrike()
    {
        currentStrikes++;
        if (currentStrikes == maxStrikes)
        {
            GameOver();
        }
        else
        {
            StrikeWarning();
        }

        switch (currentStrikes)
        {
            case 1:
                strikesText.text = "X      ";
                break;
            case 2:
                strikesText.text = "X  X   ";
                break;
            case 3:
                strikesText.text = "X  X  X";
                break;
            default:
                break;
        }
    }

    private void GameOver()
    {
        StrikeWarning();
        GetComponent<EndGameSystem>().ShowDefeatScreen(false);
    }

    private void StrikeWarning()
    {
        Debug.Log("Warning: Unautorized maneuver!");
        AudioManager.Instance.Play("Strike");
        AudioManager.Instance.PlayScold();
    }
}
