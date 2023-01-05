using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutBumper_R_LHE : MonoBehaviour
{
    public float speed = 1;
    public float moveDist = 2.5f;

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
        if (state == State.MoveRight)
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
           
            if (dir.magnitude >= moveDist)
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
           
            if (dir.magnitude <= 0.01f)
            {
                state = State.MoveRight;
            }
        }
    }
}
