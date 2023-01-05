using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlizzardFanMove_LHE1 : MonoBehaviour
{
    //public float amplitude = 0.5f;
    //public float period = 2;
    public float speed = 5;

    Vector3 originPosition;
    Vector3 dir;

    public enum State
    {
        MoveRight,
        MoveLeft        
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        state = State.MoveRight;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.MoveRight)
        {
            UpdateMoveRight();
        }
        else if (state == State.MoveLeft)
        {
            UpdateMoveLeft();
        }
    }

    private void UpdateMoveRight()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            transform.position += transform.right * speed * Time.fixedDeltaTime;
            dir = transform.position - originPosition;
            //if(dir.magnitude < 6)
            //{
            //    transform.position += transform.right * speed * Time.fixedDeltaTime;
            //}
            //else
            //{
            //    state = State.MoveLeft;
            //}
            if (dir.magnitude >= 6)
            {
                state = State.MoveLeft;
            }
        }
    }

    private void UpdateMoveLeft()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            transform.position += -transform.right * speed * Time.fixedDeltaTime;
            dir = transform.position - originPosition;
            //if (dir.magnitude < 6)
            //{
            //    transform.position += -transform.right * speed * Time.fixedDeltaTime;
            //}
            //else
            //{
            //    state = State.MoveRight;
            //}
            if (dir.magnitude >= 6)
            {
                state = State.MoveRight;
            }
        }
    }

    private void FixedUpdate()
    {
        //float x = amplitude * Mathf.Sin(Time.time * period);
        //transform.position += transform.right * x * speed * Time.fixedDeltaTime;
    }
}
