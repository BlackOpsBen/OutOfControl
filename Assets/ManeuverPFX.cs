using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeuverPFX : MonoBehaviour
{
    [SerializeField] private PFXGroup[] pfxGroups;

    private void Awake()
    {
        foreach (PFXGroup pfxGroup in pfxGroups)
        {
            pfxGroup.pfxSystems = pfxGroup.pfxGroupObject.GetComponentsInChildren<ParticleSystem>();
        }
    }

    public void SetPFXPlaying(string maneuver, bool value)
    {
        for (int i = 0; i < pfxGroups.Length; i++)
        {
            if (pfxGroups[i].maneuver == maneuver)
            {
                foreach (ParticleSystem pfxSystem in pfxGroups[i].pfxSystems)
                {
                    if (value)
                    {
                        if (pfxSystem.isStopped)
                        {
                            pfxSystem.Play();
                        }
                    }
                    else
                    {
                        if (pfxSystem.isPlaying)
                        {
                            pfxSystem.Stop();
                        }
                    }
                }
            }
        }
    }

    public void SetPFXPlaying(bool value)
    {
        for (int i = 0; i < pfxGroups.Length; i++)
        {
            foreach (ParticleSystem pfxSystem in pfxGroups[i].pfxSystems)
            {
                pfxSystem.Stop();
            }
        }
    }
}

[System.Serializable]
public class PFXGroup
{
    public string maneuver;
    public GameObject pfxGroupObject;
    [HideInInspector]
    public ParticleSystem[] pfxSystems;
}
