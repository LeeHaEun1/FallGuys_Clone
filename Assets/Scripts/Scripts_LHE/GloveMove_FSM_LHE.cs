using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveMove_FSM_LHE : MonoBehaviour
{
    public float outSpeed = 1;
    public float inSpeed = 0.2f;

    public float currentTime = 0;
    public float createTime = 5;

    Vector3 inPosition;
    Vector3 outPosition;

    Vector3 glovePosition;

    float bouceForce;


    // FSM
    public enum State
    {
        GloveOut,
        GloveIn
    }
    public State state;


    // Start is called before the first frame update
    void Start()
    {
        // ���� ������ ��ġ�� (local z�� ����)
        inPosition = transform.localPosition;
        
        // �ִ� out ���� ����(local���� �ִ� 2.3f��ŭ ���� = glove�� ���� ����)
        outPosition = inPosition + new Vector3(0, 0, 2.3f);

        state = State.GloveOut;

        // ź�� �ڵ�
        // -> �̷��� �����ͼ� bounce.enabled�ϴϱ� ������.. ������ ��..
        //bounce = GetComponent<ObstaclesBounce_LHE>();

        bouceForce = GetComponent<ObstaclesBounce_LHE>().bounceForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.GloveOut)
        {
            UpdateGloveOut();
        }
        if (state == State.GloveIn)
        {
            UpdateGloveIn();
        }
        // �� ���� �� ź�� ����
        if(transform.localPosition == inPosition)
        {
            GetComponent<ObstaclesBounce_LHE>().bounceForce = 0;
        }
        else
        {
            GetComponent<ObstaclesBounce_LHE>().bounceForce = bouceForce;
        }
    }

    private void UpdateGloveOut()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            currentTime += outSpeed * Time.fixedDeltaTime;
            //currentTime = Mathf.Clamp(currentTime, 0, 1);

            glovePosition = Vector3.Lerp(inPosition, outPosition, currentTime);
            transform.localPosition = glovePosition;

            if (currentTime >= createTime)
            {   
                currentTime = 0;
                state = State.GloveIn;
            }
        }
    }

    private void UpdateGloveIn()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            currentTime += inSpeed * Time.fixedDeltaTime;
            //currentTime = Mathf.Clamp(currentTime, 0, 1);

            glovePosition = Vector3.Lerp(outPosition, inPosition, currentTime);
            transform.localPosition = glovePosition;

            if (currentTime >= createTime)
            {
                currentTime = 0;
                state = State.GloveOut;
                ;
            }
        }
    }
}
