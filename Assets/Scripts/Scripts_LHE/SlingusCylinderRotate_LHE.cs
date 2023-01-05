using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingusCylinderRotate_LHE : MonoBehaviour
{
    //public float speed = 20;
    public float upSpeed = 10;
    public float downSpeed = 1;

    public float waitingTime = 1;

    public float currentTime = 0;
    public float createTime = 3;

    IEnumerator IeFlip()
    {
        PanelUp();
        yield return new WaitForSeconds(waitingTime);
        PanelDown();
    }

    private void PanelUp()
    {
        while (transform.localEulerAngles.y < 45)
        {
            transform.Rotate(0, upSpeed * Time.deltaTime, 0);
        }
    }

    private void PanelDown()
    {
        while (transform.localEulerAngles.y > 0)
        {
            transform.Rotate(0, -downSpeed * Time.deltaTime, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, speed * Time.deltaTime, 0);
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            StartCoroutine("IeFlip");
            currentTime = 0;
        }
        //print(transform.rotation.y);
        //print(transform.localEulerAngles.y);
    }

    //private void FixedUpdate()
    //{
    //    currentTime += Time.fixedDeltaTime;
    //    if (currentTime > createTime)
    //    {
    //        StartCoroutine("IeFlip");
    //        currentTime = 0;
    //    }
    //}
}
