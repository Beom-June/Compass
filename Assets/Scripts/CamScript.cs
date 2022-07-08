using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    Camera cam;
    public float speed = 10.0f;

    void Awake()
    {
        // Get the camera on this gameObject and the defaultZoom.
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        CamRotate();
    }

    void CamRotate()
    {
        //Y값으로 이상하게 튀어나가는거 방지
        if (this.transform.position.y != 0)
            this.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);

        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        transform.Translate(dir * speed, Space.World);
        transform.Rotate(dir * speed * 10, Space.World);
    }
}
