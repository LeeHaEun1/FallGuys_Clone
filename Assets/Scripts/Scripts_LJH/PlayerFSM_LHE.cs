using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FSM으로 Player의 상태머신을 제어하고싶다
// 가만있을때, 이동, 점프, 슬라이딩, 넘어짐

public class PlayerFSM_LHE : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Jump,
        Dive,
        Tripped
    }
    public State state;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Idle)
        {
            UpdateIdle();
        }        
        if(state == State.Move)
        {
            UpdateMove();
        }      
        if(state == State.Jump)
        {
            UpdateJump();
        }       
        if(state == State.Dive)
        {
            UpdateDive();
        }        
        if(state == State.Tripped)
        {
            UpdateTripped();
        }
    }

    // Idle 도중 -> Move, Jump, Dive, Tripped 가능
    private void UpdateIdle()
    {
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            state = State.Move;
            anim.SetTrigger("Move");
        }
        if(PlayerMove_LHE.instance.isGrounded == true && Input.GetButtonDown("Jump"))
        {
            state = State.Jump;
            anim.SetTrigger("Jump");
        }
        // 다이브 상태로 전이
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    state = State.Dive;
        //    anim.SetTrigger("Dive");
        //}
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        //if ()
        //{
        //    state = State.Tripped;
        //    anim.SetTrigger("Tripped");
        //}
    }

    private void UpdateMove()
    {
        // 아무 키 입력도 없고 Tripped 상태도 아닐 때 Idle 상태로 전이
        if(!Input.anyKeyDown && state != State.Tripped)
        {
            state = State.Idle;
            anim.SetTrigger("Idle");
        }
        if (PlayerMove_LHE.instance.isGrounded == true && Input.GetButtonDown("Jump"))
        {
            state = State.Jump;
            anim.SetTrigger("Jump");
        }
        // 다이브 상태로 전이
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    state = State.Dive;
        //    anim.SetTrigger("Dive");
        //}
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        //if ()
        //{
        //    state = State.Tripped;
        //    anim.SetTrigger("Tripped");
        //}
    }

    private void UpdateJump()
    {
        // 다이브 상태로 전이
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    state = State.Dive;
        //    anim.SetTrigger("Dive");
        //}
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        // ★ 점프 or 다이브 중 충돌해 날아가는 상태를 따로 정의해야하나,,!?
        //if ()
        //{
        //    state = State.Tripped;
        //    anim.SetTrigger("Tripped");
        //}
    }

    private void UpdateDive()
    {
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        // ★ 점프 or 다이브 중 충돌해 날아가는 상태를 따로 정의해야하나,,!?
        //if ()
        //{
        //    state = State.Tripped;
        //    anim.SetTrigger("Tripped");
        //}
    }

    private void UpdateTripped()
    {
        
    }
}
