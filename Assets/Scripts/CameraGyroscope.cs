using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyroscope : MonoBehaviour
{
    public GameObject cam;
    float x;
    void Start()
    {
        camGyroSet();
    }

    void Update()
    {
        camRotateSet();
    }

    void camGyroSet()
    {
        //camParent = new GameObject("CamParent");
        cam.transform.position = this.transform.position;
        this.transform.parent = cam.transform;
        Input.gyro.enabled = true;
    }

    void camRotateSet()
    {
        cam.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.x, 0);
        //this.transform.Rotate(-Input.gyro.rotationRateUnbiased.y, 0, 0);
        cam.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        //this.transform.Rotate(0, 0, Input.gyro.rotationRateUnbiased.z);

    }
    void CamAngleLimit()
    {

    }
}
