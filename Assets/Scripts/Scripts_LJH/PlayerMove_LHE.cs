using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� �Է�(adws)�� ���� �յ��¿�� �̵�(Move)�ϰ�ʹ�
// �����̽��ٸ� ������ ����(Jump)�ϰ�ʹ�
// ctrlŰ�� ������ ���̺�(Dive) �ϰ�ʹ�
// ��ֹ��� �ε����� �Ѿ�����(Tripped)

public class PlayerMove_LHE : MonoBehaviour
{
    // Singleton
    public static PlayerMove_LHE instance;
    private void Awake()
    {
        instance = this;
    }

    // �̵� �ӵ�
    public float speed = 3;
    // ���� �ٴ� ��
    public float jumpPower = 500;    
    // ������� �Ÿ�(=RB�� Height/2)
    public float distToGround = 1f;
    public bool isGrounded = false;
    // RigidBody
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {           
        // [����(Jump)]
        // 1. �÷��̾ �ٴڿ� �پ��ִ��� Ȯ�� (�� GroundCheck & isGrounded �߰�!!)
        GroundCheck();
        // 2. ���� ����ڰ� "Floor�� �پ��ִ� ���(=���� ���� �ƴ� ���)" �����̽��ٸ� ������ �����ϰ�ʹ�
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, jumpPower, 0);
        }        
        // �� ���� �� �̵��ϸ� �̲������� ���� -> RB������Ʈ���� collider y�� �������� �����߽��� ���������ν� �ذ�
             


        // [���̺�(Dive)]
        // ctrlŰ�� ������ �ణ ������ ���̺� �ϰ�ʹ�
            // �� �����ϸ鼭 forward�� �÷��� �ϴ� ���·�?? �ƴϸ� ������ � ��������?
            // �� Fire1���� �ϴϱ� ���콺 ���ʹ�ư ������ ���� ��� �۵��Ѵ�,, Axes ���� ���� �ذ��ؾ��ϳ�?
            // �� �� ����� �ȵǳ�,,�ƴϸ� move���� �����Ѱ�ó�� ������ ���� 45�������� ������ ������Ű�� �Ƿ���??(6/30�غ���)
        if (isGrounded && Input.GetButtonDown("Fire1"))
        {
            
        }



        // [�̵�(Move)]
        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. �յ��¿�� ������ �����
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        // ������ ũ��� 1
        dir.Normalize();        
        // 3. �� �������� �̵��ϰ� �ʹ�(P = P0 + vt)
        transform.position += dir * speed * Time.deltaTime;
        
        

        // [�Ѿ���(Tripped)] �ִϸ��̼����� ����?
    }
    

    // [2�� ���� & 2�� ���̺� ����] �÷��̾ ���� �پ��ִ��� Ȯ��
    void GroundCheck()
    {
        if(Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
