using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{
    public float compassSmooth = 0.5f;
    private float m_lastMagneticHeading = 0f;
    void Start()
    {
        // If you need an accurate heading to true north, 
        // start the location service so Unity can correct for local deviations:
        Input.location.Start();
        // Start the compass.
        Input.compass.enabled = true;
    }
    // Update is called once per frame
    private void Update()
    {
        //do rotation based on compass
        float currentMagneticHeading = (float)Mathf.Round(2);
        if (m_lastMagneticHeading < currentMagneticHeading - compassSmooth || m_lastMagneticHeading > currentMagneticHeading + compassSmooth)
        {
            m_lastMagneticHeading = currentMagneticHeading;
            transform.localRotation = Quaternion.Euler(0, m_lastMagneticHeading, 0);
        }
    }
}
