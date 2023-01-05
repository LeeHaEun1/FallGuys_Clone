using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 입력(adws)에 따라 앞뒤좌우로 이동(Move)하고싶다
// 스페이스바를 누르면 점프(Jump)하고싶다
// ctrl키를 누르면 다이브(Dive) 하고싶다
// 장애물에 부딪히면 넘어진다(Tripped)

public class PlayerMove_LHE : MonoBehaviour
{
    // Singleton
    public static PlayerMove_LHE instance;
    private void Awake()
    {
        instance = this;
    }

    // 이동 속도
    public float speed = 3;
    // 점프 뛰는 힘
    public float jumpPower = 500;    
    // 지면과의 거리(=RB의 Height/2)
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
        // [점프(Jump)]
        // 1. 플레이어가 바닥에 붙어있는지 확인 (→ GroundCheck & isGrounded 추가!!)
        GroundCheck();
        // 2. 만약 사용자가 "Floor에 붙어있는 경우(=점프 중이 아닌 경우)" 스페이스바를 누르면 점프하고싶다
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, jumpPower, 0);
        }        
        // ★ 착지 후 이동하면 미끄러지는 현상 -> RB컴포넌트에서 collider y값 조정으로 무게중심을 낮춰줌으로써 해결
             


        // [다이브(Dive)]
        // ctrl키를 누르면 약간 앞으로 다이브 하고싶다
            // ★ 점프하면서 forward값 플러스 하는 형태로?? 아니면 포물선 운동 공식으로?
            // ★ Fire1으로 하니까 마우스 왼쪽버튼 눌렀을 때도 기능 작동한다,, Axes 새로 만들어서 해결해야하나?
            // ★ 이 방법은 안되네,,아니면 move에서 구현한것처럼 방향을 전방 45도각도로 설정해 점프시키면 되려나??(6/30해보기)
        if (isGrounded && Input.GetButtonDown("Fire1"))
        {
            
        }



        // [이동(Move)]
        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. 앞뒤좌우로 방향을 만들고
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        // 방향의 크기는 1
        dir.Normalize();        
        // 3. 그 방향으로 이동하고 싶다(P = P0 + vt)
        transform.position += dir * speed * Time.deltaTime;
        
        

        // [넘어짐(Tripped)] 애니메이션으로 구현?
    }
    

    // [2단 점프 & 2단 다이브 방지] 플레이어가 땅에 붙어있는지 확인
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
