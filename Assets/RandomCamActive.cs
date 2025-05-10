using System;
using UnityEngine;

public class RandomCamActive : MonoBehaviour
{
    public GameObject[] cameras;
    void Start()
    {
        InvokeRepeating("UpdateCameras",0,5);
    }
    public void UpdateCameras()
    {
        foreach (var cam in cameras)
        {
            cam.SetActive(false);
        }
        cameras[UnityEngine.Random.Range(0, cameras.Length)].SetActive(true);
    }
}
