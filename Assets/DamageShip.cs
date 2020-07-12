using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShip : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
