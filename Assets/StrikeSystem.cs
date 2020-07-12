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
        Debug.Log("Game over! Too many strikes!");
    }

    private void StrikeWarning()
    {
        Debug.Log("Warning: Unautorized maneuver!");
    }
}
