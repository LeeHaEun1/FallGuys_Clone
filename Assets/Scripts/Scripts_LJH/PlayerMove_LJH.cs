using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_LJH : MonoBehaviour
{
    enum PlayerState
    {
        Idle,
        Move,
        Jump,
        Diving,
        Getup,
        Tripped//넘어짐
    }

    PlayerState playerState;
    public float diveY, diveZ;
    public float jumpPower = 5f;
    public float rotateSpeed = 5f;
    public Animator playerAnim;
    bool isGround;
    bool isTripped; //장애물과 부딪히면 true
    int diveCount;

    float speed = 5;
    public Rigidbody rb;
    public BoxCollider boxCollider;
    public GameObject playerParent;

    void Start()
    {
        diveCount = 0;
        isGround = true;
        playerState = PlayerState.Idle;
        isTripped = false;
    }

    void Update()
    {
        Vector3 tmpPos = playerParent.transform.position;
        tmpPos.y -= 0.5f;
        transform.position = tmpPos;
        isGround = Physics.Raycast(transform.position, Vector3.down, boxCollider.bounds.extents.y + 0.01f);

        //사용자의 입력에 따라 상하좌우로 이동
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //방향
        Vector3 dir = (Vector3.right * h) + (Vector3.forward * v);
        //이동
        transform.Translate(dir * speed * Time.deltaTime);
        //dir(방향) * speed(크기) = v
        //Time.deltaTime = t


        switch (playerState)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Move:
                UpdateMove();
                break;
            case PlayerState.Jump:
                UpdateMove();
                break;
            case PlayerState.Diving:
                UpdateDiving();
                break;
            case PlayerState.Getup:
                UpdateGetup();
                break;
            case PlayerState.Tripped:
                UpdateTripped();
                break;
        }

    }
    //@@anim Trigger Move, Jump 필요
    //@@장애물에 collider 컴포넌트 부착 + tag로 obstacle 지정 필요
    void UpdateIdle()
    {
        //move로 전환
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            playerState = PlayerState.Move;
            playerAnim.SetTrigger("Move");
        }

        //jump로 전환
        if (PlayerMove_LHE.instance.isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerState = PlayerState.Jump;
            playerAnim.SetTrigger("Jump");
        }

        //다이빙으로 전환 및 다이빙 움직임
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0&& playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            Debug.Log("2");
            playerAnim.SetTrigger("dive");
            isGround = false;

            rb.AddForce(0, diveY, diveZ);
        }

        //넘어짐으로 전환
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    private void UpdateMove()
    {
        // 아무 키 입력도 없고 Tripped 상태도 아닐 때 Idle 상태로 전이
        if (!Input.anyKeyDown && playerState != PlayerState.Tripped)
        {
            playerState = PlayerState.Idle;
            playerAnim.SetTrigger("Idle");
        }
        if (PlayerMove_LHE.instance.isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerState = PlayerState.Jump;
            playerAnim.SetTrigger("Jump");
            rb.AddForce(0, jumpPower, 0);
        }
        // 다이브 상태로 전이
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0 && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            Debug.Log("2");
            playerAnim.SetTrigger("dive");
            isGround = false;

            rb.AddForce(0, diveY, diveZ);
        }

        //넘어짐으로 전환
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    private void UpdateJump()
    {
        // 다이브 상태로 전이
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0 && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            Debug.Log("2");
            playerAnim.SetTrigger("dive");
            isGround = false;

            rb.AddForce(0, diveY, diveZ);
        }

        //넘어짐으로 전환
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    void UpdateDiving()
    {
        //다이브 하는 동안 회전 막기
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        isGround = Physics.Raycast(transform.position, Vector3.down, boxCollider.bounds.extents.y + 0.01f);
        if (isGround)
        {
            Debug.Log("4");
            Debug.Log("Grounded");
            playerState = PlayerState.Getup;
        }

        //넘어짐으로 전환
        // 넘어짐 상태로 전이(충돌(Hit) 함수 발생 시)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    void UpdateGetup()
    {

        //getup 애니메이션 시작
        playerAnim.SetTrigger("getUp");

        //getup 애니메이션이 끝나면 diveCount=0, idle로 돌려주기
        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Getup") && playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Debug.Log("5");
            rb.constraints = RigidbodyConstraints.None;
            diveCount = 0;
            playerState = PlayerState.Idle;
            playerAnim.SetTrigger("idle");

        }
    }

    void UpdateTripped()
    {
        if (isGround)
        {
            //일어날 수 있도록 정상 각도로 회전
            Vector3 tmpRot = playerParent.transform.eulerAngles;
            tmpRot.x = 0f;

            playerParent.transform.eulerAngles = Vector3.Slerp(playerParent.transform.eulerAngles, tmpRot, rotateSpeed);

            //getUp으로 전환
            if (playerParent.transform.eulerAngles.x == 0)
                playerState = PlayerState.Getup;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            isTripped = true;
        }
    }
}
