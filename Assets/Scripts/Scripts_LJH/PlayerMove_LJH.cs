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
        Tripped//�Ѿ���
    }

    PlayerState playerState;
    public float diveY, diveZ;
    public float jumpPower = 5f;
    public float rotateSpeed = 5f;
    public Animator playerAnim;
    bool isGround;
    bool isTripped; //��ֹ��� �ε����� true
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

        //������� �Է¿� ���� �����¿�� �̵�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //����
        Vector3 dir = (Vector3.right * h) + (Vector3.forward * v);
        //�̵�
        transform.Translate(dir * speed * Time.deltaTime);
        //dir(����) * speed(ũ��) = v
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
    //@@anim Trigger Move, Jump �ʿ�
    //@@��ֹ��� collider ������Ʈ ���� + tag�� obstacle ���� �ʿ�
    void UpdateIdle()
    {
        //move�� ��ȯ
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            playerState = PlayerState.Move;
            playerAnim.SetTrigger("Move");
        }

        //jump�� ��ȯ
        if (PlayerMove_LHE.instance.isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerState = PlayerState.Jump;
            playerAnim.SetTrigger("Jump");
        }

        //���̺����� ��ȯ �� ���̺� ������
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0&& playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            Debug.Log("2");
            playerAnim.SetTrigger("dive");
            isGround = false;

            rb.AddForce(0, diveY, diveZ);
        }

        //�Ѿ������� ��ȯ
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    private void UpdateMove()
    {
        // �ƹ� Ű �Էµ� ���� Tripped ���µ� �ƴ� �� Idle ���·� ����
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
        // ���̺� ���·� ����
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0 && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            Debug.Log("2");
            playerAnim.SetTrigger("dive");
            isGround = false;

            rb.AddForce(0, diveY, diveZ);
        }

        //�Ѿ������� ��ȯ
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    private void UpdateJump()
    {
        // ���̺� ���·� ����
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0 && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            Debug.Log("2");
            playerAnim.SetTrigger("dive");
            isGround = false;

            rb.AddForce(0, diveY, diveZ);
        }

        //�Ѿ������� ��ȯ
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    void UpdateDiving()
    {
        //���̺� �ϴ� ���� ȸ�� ����
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        isGround = Physics.Raycast(transform.position, Vector3.down, boxCollider.bounds.extents.y + 0.01f);
        if (isGround)
        {
            Debug.Log("4");
            Debug.Log("Grounded");
            playerState = PlayerState.Getup;
        }

        //�Ѿ������� ��ȯ
        // �Ѿ��� ���·� ����(�浹(Hit) �Լ� �߻� ��)
        if (isTripped)
        {
            playerState = PlayerState.Tripped;
            isTripped = false;
        }
    }

    void UpdateGetup()
    {

        //getup �ִϸ��̼� ����
        playerAnim.SetTrigger("getUp");

        //getup �ִϸ��̼��� ������ diveCount=0, idle�� �����ֱ�
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
            //�Ͼ �� �ֵ��� ���� ������ ȸ��
            Vector3 tmpRot = playerParent.transform.eulerAngles;
            tmpRot.x = 0f;

            playerParent.transform.eulerAngles = Vector3.Slerp(playerParent.transform.eulerAngles, tmpRot, rotateSpeed);

            //getUp���� ��ȯ
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
