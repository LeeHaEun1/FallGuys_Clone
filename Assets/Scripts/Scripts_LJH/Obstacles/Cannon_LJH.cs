using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_LJH : MonoBehaviour
{
    //����ġ�� ������
    //�� ������Ʈ�� ��� �ʹ�
    public GameObject cannonStarFactory;
    public CannonSwitch cannonSwitch;
    GameObject torus;

    void Start()
    {
        torus = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //����ġ�� ������
        //if(cannonSwitch.isPush)
        //{
        //    GameObject star = Instantiate(cannonStarFactory);
        //    star.transform.position = torus.transform.position;
        //    cannonSwitch.isPush = false;
        //}
    }
}
