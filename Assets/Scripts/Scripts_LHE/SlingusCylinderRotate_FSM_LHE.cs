using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingusCylinderRotate_FSM_LHE : MonoBehaviour
{
    public float upSpeed = 1;
    public float downSpeed = 0.2f;

    public float currentTime = 0;
    public float createTime = 5;

    Quaternion from;
    Quaternion to;

    Quaternion rotating;

    // 탄성 on off
    public float bouceForce;

    // FSM
    public enum State
    {
        PanelUp,
        PanelDown
    }
    public State state;


    // Start is called before the first frame update
    void Start()
    {
        from = Quaternion.Euler(0, 0, 0);
        to = Quaternion.Euler(0, 45, 0);

        state = State.PanelUp;

        bouceForce = GetComponentInChildren<ObstaclesBounce_LHE>().bounceForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.PanelUp)
        {
            UpdatePanelUp();
        }
        if (state == State.PanelDown)
        {
            UpdatePanelDown();
        }
        // 들어가 있을 때 탄성 제거
        if (transform.localEulerAngles.y == 0)
        {
            GetComponentInChildren<ObstaclesBounce_LHE>().bounceForce = 0;
        }
        else
        {
            GetComponentInChildren<ObstaclesBounce_LHE>().bounceForce = bouceForce;
        }
        
    }

    private void UpdatePanelUp()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            currentTime += upSpeed * Time.fixedDeltaTime;

            rotating = Quaternion.Lerp(from, to, currentTime);
            transform.localRotation = rotating;

            if (currentTime >= createTime)
            {
                currentTime = 0;
                state = State.PanelDown;
            }
        }
    }

    private void UpdatePanelDown()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            currentTime += downSpeed * Time.fixedDeltaTime;

            rotating = Quaternion.Lerp(to, from, currentTime);
            transform.localRotation = rotating;

            if (currentTime >= createTime)
            {
                currentTime = 0;
                state = State.PanelUp;
            }
        }
    }
}
