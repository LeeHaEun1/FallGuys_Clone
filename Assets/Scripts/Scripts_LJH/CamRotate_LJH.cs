using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate_LJH : MonoBehaviour
{
    //������� ���콺 �Է��� �޾� ī�޶� ȸ����Ű�� �ʹ�.
    //ȸ�� �ӵ� ���� �ʿ�
    //ȸ�� �� �̸� ���� ���� �ʿ�

    public GameObject camPos;
    public float rotSpeed = 300f;
    public GameObject target;
    float mx = 0;
    float my = 0;
    // Update is called once per frame
    void Update()
    {
        //1. ���콺 �Է� �ޱ�
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");


        //2. ȸ�� �� ������ ���콺 �Է� �� ������Ű��
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        //3. ���콺 ���� �̵� ȸ�� ����(my)�� ���� -90~90�� ���̷� �����ϱ�
        my = Mathf.Clamp(my, -90f, 90f);

        //4. ȸ�� �������� ī�޶� ȸ����Ű��
        //�÷��̾��� ������Ʈ�� camPos�ڽ� ������Ʈ�� ȸ����Ű�� @@
        camPos.transform.RotateAround(target.transform.position, Vector3.up, mouse_X * Time.deltaTime * rotSpeed);
        //transform.eulerAngles = new Vector3(-my, mx, 0);

        transform.LookAt(target.transform.position);
    }
}
