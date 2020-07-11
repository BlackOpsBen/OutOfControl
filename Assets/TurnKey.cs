using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnKey : MonoBehaviour
{
    [SerializeField] private Button executeButton;

    public void SetKeyTurn()
    {
        executeButton.interactable = !executeButton.interactable;
    }
}
