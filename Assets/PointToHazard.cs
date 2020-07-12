using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToHazard : MonoBehaviour
{
    private Transform target;

    private bool isApproaching = false;
    private float prevDist;
    private float currentDist;

    private float alpha = 0f;

    private float alphaChangeSpeed = 1f;
    private float direction = 1f;

    private MeshRenderer mRenderer;

    private void Awake()
    {
        mRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            // Rotate to point to target
            transform.rotation = Quaternion.LookRotation((target.position - transform.position).normalized, Vector3.up);

            currentDist = Vector3.Distance(transform.position, target.position);

            if (currentDist > prevDist)
            {
                isApproaching = false;
            }
            else
            {
                isApproaching = true;
            }

            prevDist = currentDist;

            if (isApproaching)
            {
                direction = 1f;
            }
            else
            {
                direction = -1f;
            }

            mRenderer.material.SetColor("_Color", new Color(mRenderer.material.color.r, mRenderer.material.color.g, mRenderer.material.color.b, Mathf.Clamp(mRenderer.material.color.a + (alphaChangeSpeed * direction * Time.deltaTime), 0f, 1f)));

        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
