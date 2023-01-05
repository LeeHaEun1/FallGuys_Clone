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
        // 시작 시점의 위치와 (local z값 저장)
        inPosition = transform.localPosition;
        
        // 최대 out 지점 지정(local기준 최대 2.3f만큼 나감 = glove의 가로 길이)
        outPosition = inPosition + new Vector3(0, 0, 2.3f);

        state = State.GloveOut;

        // 탄성 코드
        // -> 이렇게 가져와서 bounce.enabled하니까 오류뜸.. 이유는 모름..
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
        // 들어가 있을 때 탄성 제거
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
