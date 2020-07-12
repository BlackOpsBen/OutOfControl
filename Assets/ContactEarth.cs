using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactEarth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Earth")
        {
            Debug.Log("VICTORY");
            FindObjectOfType<EndGameSystem>().ShowVictoryScreen();
        }
    }
}
