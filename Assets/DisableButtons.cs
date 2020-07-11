using UnityEngine.UI;
using UnityEngine;

public class DisableButtons : MonoBehaviour
{
    public static DisableButtons Instance { get; private set; }

    [SerializeField] Button[] buttons;

    private void Awake()
    {
        SingletonPattern();
    }

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ToggleButtons(bool value)
    {
        foreach (Button button in buttons)
        {
            button.interactable = value;
        }
    }
}
