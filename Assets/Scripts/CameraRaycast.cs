using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private Camera mainCamera;

    // 충돌 체크를 위한 변수
    private RaycastHit rayHit;
    private Ray ray;

    public bool ProgressBool = false;
     GameObject findProgressBar;
    ProgressUI progrssUI;
    // 얼마나 멀리 있는 물체까지 반응할 것 인지
    public float MAX_RAY_DISTANCE = 200f;

    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        RayUpdate();
    }

    void RayUpdate()
    {
        // 화면 가운데에 광선 쏘기
        ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // 카메라 레이에 맞으면?
        if (Physics.Raycast(ray, out rayHit, MAX_RAY_DISTANCE))
        {
            Debug.DrawLine(ray.origin, rayHit.point, Color.green);
            Debug.Log("현재 쳐다 보는 것 ::: " + rayHit.transform.name);

            // 프로그래스바 True
            ProgressBool = true;
            if (ProgressBool == true)
            {
                GameObject.Find("Canvas").transform.Find("ProgressSpinner").gameObject.SetActive(true);
            }
        }

        // 카메라 레이에 안 맞으면?
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            // 프로그래스바 False
            ProgressBool = false;
            if (ProgressBool == false)
            {
                GameObject.Find("Canvas").transform.Find("ProgressSpinner").gameObject.SetActive(false);
                // Fill 도 0으로 만들어줌
                GameObject.Find("Canvas").transform.Find("ProgressSpinner").gameObject.GetComponent<ProgressUI>().currentAmount = 0;
            }
        }
    }
}

