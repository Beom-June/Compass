using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GPSManager : MonoBehaviour
{
    public static float magneticHeading;            // �ںϱؿ� ���� ���� ��ȯ (0 ~ 360)
    public static float trueHeading;                // ������ �ϱؿ� ���� ���� ��ȯ (0 ~ 360)

    private void Awake()
    {
        Input.location.Start();                     // ��ġ ���� ����
        Input.compass.enabled = true;               // ��ħ�� Ȱ��ȭ

        // GPS ����ϱ� ���ؼ� Ȯ��
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
            //��� �� ��������
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