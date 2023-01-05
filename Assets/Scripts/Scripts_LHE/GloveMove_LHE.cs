using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveMove_LHE : MonoBehaviour
{
    public float outSpeed = 10;
    public float inSpeed = 1;

    public float waitingTime = 1;

    public float currentTime = 0;
    public float createTime = 3;

 
    IEnumerator IePunch()
    {
        GloveOut();              
        yield return new WaitForSeconds(waitingTime);            
        GloveIn();             
    }

    private void GloveOut()
    {
        while(transform.localPosition.z <= 2.3f)
        {
            transform.position += transform.forward * outSpeed * 0.05f * Time.fixedDeltaTime;
        }
    }

    private void GloveIn()
    {
        while(transform.localPosition.z >= 0.05f)
        {
            transform.position += -transform.forward * inSpeed * 0.05f * Time.fixedDeltaTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //print(transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        //currentTime += Time.deltaTime;
        //if (currentTime > createTime)
        //{
        //    StartCoroutine("IePunch");
        //    currentTime = 0;
        //}       
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime > createTime)
        {
            StartCoroutine("IePunch");
            currentTime = 0;
        }
    }
}
