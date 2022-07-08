using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public GameObject cam;
    void Start()
    {
        cam = new GameObject("Cam");
        cam.transform.position = this.transform.position;

        this.transform.parent = cam.transform;
        Input.gyro.enabled = true;
    }

    void Update()
    {
        cam.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
    }
}
