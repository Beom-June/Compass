using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;

    public Text lat;
    public Text lon;

    void Awake()
    {
        Input.location.Start();                     // 위치 서비스 시작
        Input.compass.enabled = true;               // 나침반 활성화
        // GPS 사용하기 위해서 확인
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }

    private void Update()
    {
        Test();
    }
    void Start()
    {
        StartCoroutine(StartLocationService());
        //InvokeRepeating("StartLocationService", 1, 2);
    }

    IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("유저가 GPS 사용 불가.");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1f);
            maxWait--;
        }
        if (maxWait <= 0)
        {
            Debug.Log("Time Out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;
    }

    void Test()
    {
        if (Input.location.status != LocationServiceStatus.Running)
        {

            Input.location.Start(0.001f, 0.001f);
        }
        lat.text = Input.location.lastData.latitude.ToString();
        lon.text = Input.location.lastData.longitude.ToString();
    }
}
