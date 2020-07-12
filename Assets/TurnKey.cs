using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnKey : MonoBehaviour
{
    [SerializeField] private Button executeButton;
    [SerializeField] private MollyGuard mollyGuard;
    [SerializeField] private RotateKey rotateKey;

    public void SetKeyTurn()
    {
        executeButton.interactable = !executeButton.interactable;
        executeButton.gameObject.SetActive(!executeButton.gameObject.activeSelf);
        mollyGuard.ToggleMollyGuard();
        rotateKey.TurnTheKey();
    }
}
