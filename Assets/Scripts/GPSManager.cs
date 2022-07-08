using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GPSManager : MonoBehaviour
{
    public static float magneticHeading;            // 자북극에 관한 각도 반환 (0 ~ 360)
    public static float trueHeading;                // 지리적 북극에 관한 각도 반환 (0 ~ 360)

    private void Awake()
    {
        Input.location.Start();                     // 위치 서비스 시작
        Input.compass.enabled = true;               // 나침반 활성화

        // GPS 사용하기 위해서 확인
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }

    void Start()
    {
        StartCoroutine(InputCompass(1f));
    }

    IEnumerator InputCompass(float time)
    {
        while (true)
        {
            //헤딩 값 가져오기
            if (Input.compass.headingAccuracy == 0 || Input.compass.headingAccuracy > 0)
            {
                magneticHeading = Input.compass.magneticHeading;
                trueHeading = Input.compass.trueHeading;
                Debug.Log("Input");
            }

            yield return new WaitForSeconds(time);
        }
    }
}