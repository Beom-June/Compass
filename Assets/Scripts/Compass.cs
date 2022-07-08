using UnityEngine.UI;
using UnityEngine;
public class Compass : MonoBehaviour
{
    public RawImage CompassImage;
    public Transform Player;
    public Text CompassDirectionText;
    public Transform imageTriangle;
    float imutemp;
    private void Awake()
    {
    }
    public void Update()
    {
        CompassSetting();
        triangleRotation();
    }

    void CompassSetting()
    {
        //imutemp = GameObject.Find("EventSystem").GetComponent<IMU>().yaw;
        //imutemp += 115;

        // 이미지의 uvRect에 대한 핸들
        // Gyro나 기본 할때
        CompassImage.uvRect = new Rect(Player.localEulerAngles.y / 360, 0, 1, 1);

        // IMU 할 때
        //CompassImage.uvRect = new Rect(imutemp / 360, 0, 1, 1);

        // 전진벡터 받아옴
        Vector3 forward = Player.transform.forward;

        // X,Z 평면에서 방향만 얻으려면 전진 벡터의 y 성분을 0으로 함
        forward.y = 0;

        // 각도를 5도씩만 클램프
        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;

        // IMU
        //float headingAngle = imutemp;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));

        // 스위치의 플로트를 int로 변환
        int displayangle;
        displayangle = Mathf.RoundToInt(headingAngle);

        // IMU로 할 때
        //displayangle = (int)imutemp;

        // 나침반 도 텍스트의 텍스트를 클램프 값으로 설정하지만 참 방향인 경우 문자로 변경
        switch (displayangle)
        {
            case 0:
                CompassDirectionText.text = "N";
                break;
            case 360:
                CompassDirectionText.text = "N";
                break;
            case 45:
                CompassDirectionText.text = "NE";
                break;
            case 90:
                CompassDirectionText.text = "E";
                break;
            case 130:
                CompassDirectionText.text = "SE";
                break;
            case 180:
                CompassDirectionText.text = "S";
                break;
            case 225:
                CompassDirectionText.text = "SW";
                break;
            case 270:
                CompassDirectionText.text = "W";
                break;
            default:
                CompassDirectionText.text = headingAngle.ToString();
                break;
        }
    }

    void triangleRotation()
    {
        imageTriangle.transform.Rotate(Vector3.down, Time.deltaTime * 300f);
    }
}