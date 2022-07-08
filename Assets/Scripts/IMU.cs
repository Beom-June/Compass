using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class IMU : MonoBehaviour
{
    Quaternion targetRot;
    //public Text textdisplay;

    private Thread t2;
    SerialPort sp2 = new SerialPort("COM9", 115200);

    float roll;
    float pitch;
    public float yaw;
    void Start()
    {
        sp2.Open();
        sp2.NewLine = "\n";
        t2 = new Thread(Run2);
        t2.Start();
    }
    private void Update()
    {
        this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 60);
        //textdisplay.text = "ROLL : " + roll + "\nPITCH : " + pitch + "\nYAW : " + yaw ;
    }
    void Run2()
    {
        if (sp2.IsOpen)
        {
            while (true)
            {

                try
                {
                    string line = sp2.ReadLine();
                    //Debug.Log(line);
                    string[] value_init = line.Split(",".ToCharArray());
                    value_init[0] = value_init[0].Replace("*", "");
                    //Debug.Log(value_init.Length);
                    if (value_init.Length == 3)
                    {
                        roll = -float.Parse(value_init[0]);
                        pitch = -float.Parse(value_init[1]);
                        yaw = -float.Parse(value_init[2]);
                    }

                    //targetRot = Quaternion.Euler(pitch, yaw, roll);
                    //targetRot = Quaternion.Euler(0 , yaw ,roll);
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                }
            }
        }
    }
    private void OnDestroy()
    {
        //sp2.Write("<posz>");
        sp2.Close();
    }
}