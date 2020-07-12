using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    [SerializeField] GameObject destroyPFX;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        DestroyThis();
    }

    private void DestroyThis()
    {
        Instantiate(destroyPFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        AudioManager.Instance.Play("Explosion");
    }
}
