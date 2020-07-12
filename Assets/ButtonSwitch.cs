using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    [SerializeField] private float localYPos;

    private float inactiveYPos = 0f;
    private float activeYPos = -1.3f;

    [SerializeField] private bool isActive = false;

    private float speed = 10f;

    // Visual changes
    [SerializeField] private Color offColor;
    [SerializeField] private Color onColor;

    private MeshRenderer mRenderer;

    private void Awake()
    {
        localYPos = transform.localPosition.y;
        mRenderer = GetComponent<MeshRenderer>();
        mRenderer.material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        float desiredLocalYPos;
        if (isActive)
        {
            desiredLocalYPos = activeYPos;
            mRenderer.material.SetColor("_EmissionColor", onColor);
        }
        else
        {
            desiredLocalYPos = inactiveYPos;
            mRenderer.material.SetColor("_EmissionColor", offColor);
        }

        Vector3 desiredLocalPos = new Vector3(transform.localPosition.x, desiredLocalYPos, transform.localPosition.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, desiredLocalPos, Time.deltaTime * speed);
    }

    public void ToggleButtonActive(bool value)
    {
        isActive = value;
    }
}
