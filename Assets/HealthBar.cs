using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform healthBar;

    private float maxBarSize = 320f;

    private Health health;

    private void Awake()
    {
        health = FindObjectOfType<Health>();
    }

    private void Update()
    {
        healthBar.sizeDelta = new Vector2(Mathf.Lerp(0f, maxBarSize, health.GetCurrentHealthFactor()), healthBar.rect.height);
    }
}
