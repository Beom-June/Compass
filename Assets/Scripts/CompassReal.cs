using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassReal : MonoBehaviour
{
    private void Start()
    {
        Input.gyro.enabled = true;
    }
    void Update()
    {
        // Orient an object to point northward.
        transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
    }
}
