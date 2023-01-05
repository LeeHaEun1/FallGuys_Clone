using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_LJH : MonoBehaviour
{
    //스위치가 눌리면
    //별 오브젝트를 쏘고 싶다
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
        //스위치가 눌리면
        //if(cannonSwitch.isPush)
        //{
        //    GameObject star = Instantiate(cannonStarFactory);
        //    star.transform.position = torus.transform.position;
        //    cannonSwitch.isPush = false;
        //}
    }
}
