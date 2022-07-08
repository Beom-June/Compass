﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [Range(0, 100)]
    public float fillValue = 0;
    public Image circleFillImage;
    public RectTransform handlerEdgeImage;
    public RectTransform fillHandler;


    void Update()
    {
        FillCircleValue(fillValue);
    }

    void FillCircleValue(float value)
    {
        float fillAmount = (value / 100.0f);
        circleFillImage.fillAmount = fillAmount;
        float angle = fillAmount * 360;
        fillHandler.localEulerAngles = new Vector3(0, 0, -angle);
        handlerEdgeImage.localEulerAngles = new Vector3(0, 0, angle);
    }
}
