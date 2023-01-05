using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingusMove_LHE : MonoBehaviour
{
    public float speed = 10;

    public enum State
    {
        MoveLeft,
        MoveRight
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.MoveLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.MoveLeft)
        {
            UpdateMoveLeft();
        }
        else if (state == State.MoveRight)
        {
            UpdateMoveRight();
        }
    }

   
    private void UpdateMoveLeft()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
                transform.Rotate(0, 0, -speed * Time.deltaTime);
            if(transform.rotation.z <= -0.6)
            {
                state = State.MoveRight;
            }        
        }
    }
    private void UpdateMoveRight()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            if (transform.rotation.z >= 0.6)
            {
                state = State.MoveLeft;
            }
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }

}
