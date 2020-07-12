using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [SerializeField] GameObject destroyPFX;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void DealDamage(float amount)
    {
        Debug.Log("Dealt " + amount + " damage to ship!");
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth == float.Epsilon)
        {
            DestroyThis();
        }
    }

    private void DestroyThis()
    {
        Instantiate(destroyPFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        AudioManager.Instance.Play("Explosion");
    }
}
