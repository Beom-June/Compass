using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
    //UI Text to show GPS values
    public Text GPSStatus;
    public Text latitudeValue;
    public Text longitudeValue;
    public Text altitudeValue;
    public Text horizontalAccuracyValue;
    public Text timestampValue;

    void Awake()
    {
        // GPS 사용하기 위해서 확인
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
    void Start()
    {
        StartCoroutine(GPSLoc());
    }
    IEnumerator GPSLoc()
    {
        // 1. 사용자가 위치 서비스를 사용하도록 설정했는지 확인합니다.
        if (!Input.location.isEnabledByUser)
            yield break;

        // 위치를 쿼리하기 전에 서비스 시작
        Input.location.Start();

        // 서비스가 초기화될 때까지 대기
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(0.5f);
            maxWait--;
        }

        // 서비스가 20초 내에 초기화되지 않으면
        if (maxWait < 1)
        {
            GPSStatus.text = "Time out";
            yield break;
        }

        // 연결 실패시
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            // 액세스 권한 및 위치 값을 검색할 수 있습니다.
            // 0.5초 후 UpdateGPSDATA를 처음 호출한 후 1초 후에 UpdateGPSDATA를 호출하고 반복합니다.
            GPSStatus.text = "Running";
            //InvokeRepeating("UpdateGPSData", 0.1f, 0.5f);
            StartCoroutine("UpdateGPSData");

        }

        // 위치 업데이트를 계속 쿼리할 필요가 없는 경우 서비스 중지
        //Input.location.Stop();
    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timestampValue.text = Input.location.lastData.timestamp.ToString();
        }
        else
        {
            GPSStatus.text = "Stop";
        }
    }
}
