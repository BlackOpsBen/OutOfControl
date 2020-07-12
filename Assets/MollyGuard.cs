using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyGuard : MonoBehaviour
{
    [SerializeField] private const float closedXRot = 84.9f;
    [SerializeField] private const float openXRot = 140f;
    private float speed = 3.5f;

    [SerializeField] private float rotation;

    private bool isOpen = false;

    private void Update()
    {
        if (isOpen)
        {
            if (rotation < openXRot)
            {
                rotation += Time.deltaTime * speed * Mathf.Lerp(100f, 10f, Mathf.InverseLerp(closedXRot + ((openXRot - closedXRot)/2), openXRot, rotation));
            }
            //rotation = Mathf.Lerp(rotation, openXRot, Time.deltaTime * speed);
        }
        else
        {
            if (rotation > closedXRot)
            {
                rotation -= Time.deltaTime * speed * Mathf.Lerp(100f, 10f, Mathf.InverseLerp(closedXRot + ((openXRot - closedXRot) / 2), openXRot, rotation));
                //rotation -= Time.deltaTime * speed * 100f;
            }
        }

        rotation = Mathf.Clamp(rotation, closedXRot, openXRot);
        transform.rotation = Quaternion.Euler(new Vector3(rotation, 0f, 180f));
        //Debug.Log(transform.rotation.eulerAngles);
    }
    public void ToggleMollyGuard()
    {
        if (isOpen)
        {
            AudioManager.Instance.Play("Molly_Close");
        }
        else
        {
            AudioManager.Instance.Play("Molly_Open");
        }

        isOpen = !isOpen;
    }
}
