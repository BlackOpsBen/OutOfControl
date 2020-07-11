using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    public int genWidth = 100;
    public int genHeight = 100;

    public int worldWidth = 1000;
    public int worldHeight = 1000;

    private void Start()
    {
        for (int x = 0; x < genWidth; x++)
        {
            for (int y = 0; y < genHeight; y++)
            {

            }
        }
    }




}
