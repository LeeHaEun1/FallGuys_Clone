using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate_LJH : MonoBehaviour
{
    //사용자의 마우스 입력을 받아 카메라를 회전시키고 싶다.
    //회전 속도 변수 필요
    //회전 값 미리 담을 변수 필요

    public GameObject camPos;
    public float rotSpeed = 300f;
    public GameObject target;
    float mx = 0;
    float my = 0;
    // Update is called once per frame
    void Update()
    {
        //1. 마우스 입력 받기
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");


        //2. 회전 값 변수에 마우스 입력 값 누적시키기
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        //3. 마우스 상하 이동 회전 변수(my)의 값을 -90~90도 사이로 제한하기
        my = Mathf.Clamp(my, -90f, 90f);

        //4. 회전 방향으로 카메라 회전시키기
        //플레이어의 오브젝트의 camPos자식 오브젝트를 회전시키기 @@
        camPos.transform.RotateAround(target.transform.position, Vector3.up, mouse_X * Time.deltaTime * rotSpeed);
        //transform.eulerAngles = new Vector3(-my, mx, 0);

        transform.LookAt(target.transform.position);
    }
}
