using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FSM���� Player�� ���¸ӽ��� �����ϰ�ʹ�
// ����������, �̵�, ����, �����̵�, �Ѿ���

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

    // Idle ���� -> Move, Jump, Dive, Tripped ����
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
        // ���̺� ���·� ����
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    state = State.Dive;
        //    anim.SetTrigger("Dive");
        //}
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        //if ()
        //{
        //    state = State.Tripped;
        //    anim.SetTrigger("Tripped");
        //}
    }

    private void UpdateMove()
    {
        // �ƹ� Ű �Էµ� ���� Tripped ���µ� �ƴ� �� Idle ���·� ����
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
        // ���̺� ���·� ����
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    state = State.Dive;
        //    anim.SetTrigger("Dive");
        //}
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        //if ()
        //{
        //    state = State.Tripped;
        //    anim.SetTrigger("Tripped");
        //}
    }

    private void UpdateJump()
    {
        // ���̺� ���·� ����
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    state = State.Dive;
        //    anim.SetTrigger("Dive");
        //}
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        // �� ���� or ���̺� �� �浹�� ���ư��� ���¸� ���� �����ؾ��ϳ�,,!?
        //if ()
        //{
        //    state = State.Tripped;
        //    anim.SetTrigger("Tripped");
        //}
    }

    private void UpdateDive()
    {
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        // �� ���� or ���̺� �� �浹�� ���ư��� ���¸� ���� �����ؾ��ϳ�,,!?
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
