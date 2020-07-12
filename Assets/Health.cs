using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [SerializeField] GameObject destroyPFX;

    [SerializeField] GameObject shipModel;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void DealDamage(float amount)
    {
        Debug.Log("Dealt " + amount + " damage to ship! Remaining health: " + currentHealth);
        currentHealth -= amount;
        //currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth < 0f)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Instantiate(destroyPFX, transform.position, Quaternion.identity);
        shipModel.SetActive(false);
        AudioManager.Instance.Play("Explosion");
        FindObjectOfType<EndGameSystem>().ShowDefeatScreen(true);
    }

    public float GetCurrentHealthFactor()
    {
        return Mathf.InverseLerp(0f, maxHealth, currentHealth);
    }
}
