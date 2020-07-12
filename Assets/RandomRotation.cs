using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private float randSpinX;
    private float randSpinY;
    private float randSpinZ;

    private float speed = 100f;

    Vector3 randRotation;

    private void Awake()
    {
        randSpinX = UnityEngine.Random.Range(0f, 100f);
        randSpinY = UnityEngine.Random.Range(0f, 100f);
        randSpinZ = UnityEngine.Random.Range(0f, 100f);

        randRotation = new Vector3(randSpinX, randSpinY, randSpinZ);
    }

    private void Update()
    {
        transform.rotation = transform.rotation * Quaternion.AngleAxis(Time.deltaTime * speed, randRotation);
    }
}
