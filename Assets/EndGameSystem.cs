using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSystem : MonoBehaviour
{
    [SerializeField] private GameObject defeatScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject reasonDestroyed;
    [SerializeField] private GameObject reasonUnauthorized;

    private void Awake()
    {
        defeatScreen.SetActive(false);
        victoryScreen.SetActive(false);
        restartButton.SetActive(false);
        reasonDestroyed.SetActive(false);
        reasonUnauthorized.SetActive(false);
    }

    public void ShowDefeatScreen(bool destroyed)
    {
        if (destroyed)
        {
            reasonDestroyed.SetActive(true);
        }
        else
        {
            reasonUnauthorized.SetActive(true);
        }

        defeatScreen.SetActive(true);
        ShowRestartButton();
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        ShowRestartButton();
    }

    private void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }
}
