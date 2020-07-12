using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKey : MonoBehaviour
{
    [SerializeField] private const float defaultZRot = 180f;
    [SerializeField] private const float activeZRot = 270f;

    private float speed = 4f;

    [SerializeField] private float rotation = 180f;

    private bool isActive = false;

    private void Update()
    {
        if (isActive)
        {
            if (rotation < activeZRot)
            {
                rotation += Time.deltaTime * speed * 100f;
            }
        }
        else
        {
            if (rotation > defaultZRot)
            {
                rotation -= Time.deltaTime * speed * 100f;
            }
        }

        rotation = Mathf.Clamp(rotation, defaultZRot, activeZRot);
        transform.rotation = Quaternion.Euler(new Vector3(84.9f, 0f, rotation));
        //Debug.Log(transform.rotation.eulerAngles);
    }

    public void TurnTheKey()
    {
        isActive = !isActive;
        AudioManager.Instance.Play("Key");
    }
}
