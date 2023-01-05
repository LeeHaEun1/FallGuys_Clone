using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm_LJH : MonoBehaviour
{

    [SerializeField] float minX, maxX;
    [SerializeField] Transform cmCamera;
    [SerializeField] Transform target;
    public static Vector3 camForward;


    void Update()
    {
        transform.position = target.position;

        Vector2 mouseDelta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(Mathf.Clamp(camAngle.x - mouseDelta.y, minX, maxX), camAngle.y + mouseDelta.x, camAngle.z);

        camForward = getCamForward();
    }

    Vector3 getCamForward()
    {
        Vector3 camFw = transform.position - cmCamera.position;
        camFw.y = 0;
        camFw.Normalize();
        return camFw;
    }
}
