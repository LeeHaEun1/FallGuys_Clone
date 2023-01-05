using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_merged : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> audioClips;
    public List<GameObject> playerEffects; 
    //0 = jump,

    public GameObject explosionFactory;
    public enum PlayerState
    {
        Idle,
        Move,
        Jump,
        Diving,
        Getup,
        Tripped
    }

    [SerializeField][Range(-1f, 0f)] float playerDownY;

    public PlayerState playerState;

    [Header("Move")]
    public float diveY, diveZ;
    public float jumpPower = 100f;
    public float getUpRotateSpeed = 1f;
    public float rotateSpeed = 10f;
    public float moveSpeed = 10f;

    public Animator playerAnim;
    public Camera mainCamera;
    bool isGround;
    bool isTripped; //��ֹ��� �ε����� true
    int diveCount;
    float hx; //Ű���� �¿� �Է� �� ��Ƴ���. ĳ���� ȸ���� ����
    Vector3 dir = Vector3.zero;
    bool isGettingUp = false;

    
    public Rigidbody rb;
    public BoxCollider boxCollider;

    [Header("Parent of this object")]
    public GameObject playerParent;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;

    private float woowooCurrTime;
    private float woowooSoundTime;
    void Start()
    {
        woowooSoundTime = Random.Range(5f, 20f);
        woowooCurrTime = 0f;
        audioSource = GameObject.FindGameObjectWithTag("PlayerSoundEffect").GetComponent<AudioSource>();
        print(playerParent.transform.rotation);
        diveCount = 0;
        isGround = true;
        playerState = PlayerState.Idle;
        playerAnim.SetTrigger("idle");
        isTripped = false;
    }

    void Update()
    {
        
        transform.localPosition = new Vector3(0, playerDownY, 0);
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        isGround = Physics.Raycast(playerParent.transform.position, -playerParent.transform.up, boxCollider.bounds.extents.y + 0.01f);

        
        if (CanvasManager_skyline_LHE.instance)
        {
            if (CanvasManager_skyline_LHE.instance.isCountFinished)
            {
                woowooCurrTime += Time.deltaTime;
                if (woowooCurrTime > woowooSoundTime)
                {
                    audioSource.clip = PlayerAudioClips_LJH.instance.playerAudioClips[1];
                    audioSource.Play();
                    woowooSoundTime = Random.Range(7f, 20f);
                }

                if (playerState != PlayerState.Diving && playerState != PlayerState.Getup)
                {
                    MovePlayer();
                }

                switch (playerState)
                {
                    case PlayerState.Idle:
                        UpdateIdle();
                        break;
                    case PlayerState.Move:
                        UpdateMove();
                        break;
                    case PlayerState.Jump:
                        UpdateJump();
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

        }

        if (CanvasManager_tundra_LHE.instance)
        {
            if (CanvasManager_tundra_LHE.instance.isCountFinished)
            
            {
                woowooCurrTime += Time.deltaTime;
                if (woowooCurrTime > woowooSoundTime)
                {
                    audioSource.clip = PlayerAudioClips_LJH.instance.playerAudioClips[1];
                    audioSource.Play();
                    woowooSoundTime = Random.Range(7f, 20f);
                }

                if (playerState != PlayerState.Diving && playerState != PlayerState.Getup)
                {
                    MovePlayer();
                }

                switch (playerState)
                {
                    case PlayerState.Idle:
                        UpdateIdle();
                        break;
                    case PlayerState.Move:
                        UpdateMove();
                        break;
                    case PlayerState.Jump:
                        UpdateJump();
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
        }

        if (CanvasManager_windmill_LHE.instance)
        {
            if (CanvasManager_windmill_LHE.instance.isCountFinished)
            {
                woowooCurrTime += Time.deltaTime;
                if (woowooCurrTime > woowooSoundTime)
                {
                    audioSource.clip = PlayerAudioClips_LJH.instance.playerAudioClips[1];
                    audioSource.Play();
                    woowooSoundTime = Random.Range(7f, 20f);
                }

                if (playerState != PlayerState.Diving && playerState != PlayerState.Getup)
                {
                    MovePlayer();
                }

                switch (playerState)
                {
                    case PlayerState.Idle:
                        UpdateIdle();
                        break;
                    case PlayerState.Move:
                        UpdateMove();
                        break;
                    case PlayerState.Jump:
                        UpdateJump();
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
        }

       


        if (CheckOnSlope())
        {
            //rb.constraints = RigidbodyConstraints.FreezeRotationX;
            //rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }

       

    }
    //@@anim Trigger Move, Jump �ʿ�
    //@@��ֹ��� collider ������Ʈ ���� + tag�� obstacle ���� �ʿ�
    void UpdateIdle()
    {
        if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            playerAnim.SetTrigger("idle");

        //move�� ��ȯ
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            playerState = PlayerState.Move;
            playerAnim.ResetTrigger("idle");
        }

        //jump�� ��ȯ
        if ((CheckOnSlope() || isGround == true) && Input.GetButtonDown("Jump"))
        {
            playerState = PlayerState.Jump;
            rb.AddForce(0, PlayerInfo_LJH.instance.jumpPower, 0);
            GameObject effect = Instantiate(playerEffects[0]);
            effect.transform.position = new Vector3(playerParent.transform.position.x,
                playerParent.transform.position.y - (boxCollider.size.y / 2),
                playerParent.transform.position.z);
            audioSource.clip = PlayerAudioClips_LJH.instance.playerAudioClips[0];
            audioSource.Play();
            //playerAnim.SetTrigger("jump");
        }

        //���̺����� ��ȯ �� ���̺� ������
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0&& playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            Debug.Log("2");
            //playerAnim.SetTrigger("dive");
            isGround = false;

            Quaternion playerYRot = Quaternion.Euler(0f, playerParent.transform.eulerAngles.y, 0f);
            rb.AddForce(playerYRot * new Vector3(0, diveY, diveZ));
        }

        //�Ѿ������� ��ȯ
        
        if (!isGround && CheckFellDown())
        {
            playerState = PlayerState.Getup;
            playerAnim.ResetTrigger("idle");
        }
        
    }

    private void UpdateMove()
    {
        if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Move"))
            playerAnim.SetTrigger("move");
        //jump
        if ((CheckOnSlope() || isGround == true) && Input.GetButtonDown("Jump"))
        {
            playerState = PlayerState.Jump;
            GameObject effect = Instantiate(playerEffects[0]);
            effect.transform.position = new Vector3(playerParent.transform.position.x,
                playerParent.transform.position.y - (boxCollider.size.y / 2),
                playerParent.transform.position.z);
            rb.AddForce(0, PlayerInfo_LJH.instance.jumpPower, 0);
            audioSource.clip = PlayerAudioClips_LJH.instance.playerAudioClips[0];
            audioSource.Play();
            playerAnim.ResetTrigger("move");
            playerAnim.SetTrigger("jump");
        }
        // dive
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0)
        {
            diveCount = 1;
            playerAnim.SetTrigger("dive");
            playerState = PlayerState.Diving;
            Debug.Log("2");
            

            Quaternion playerYRot = Quaternion.Euler(0f, playerParent.transform.eulerAngles.y, 0f);
            rb.AddForce(playerYRot * new Vector3(0, diveY, diveZ));
        }
        // �ƹ� Ű �Էµ� ���� Tripped ���µ� �ƴ� �� Idle ���·� ����
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && playerState != PlayerState.Tripped)
        {
            playerState = PlayerState.Idle;
            playerAnim.ResetTrigger("move");
        }

        //�Ѿ������� ��ȯ
        
        if (!isGround && CheckFellDown())
        {
            playerState = PlayerState.Getup;
            playerAnim.ResetTrigger("move");

        }
        
    }

    private void UpdateJump()
    {
        if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            playerAnim.SetTrigger("jump");

        if (CheckOnSlope())
            print("Jump Slope");

        if (isGround || CheckOnSlope())
        {
            playerAnim.ResetTrigger("jump");
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                playerState = PlayerState.Move;
            else
                playerState = PlayerState.Idle;
        }
        
        // ���̺� ���·� ����
        //if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0 && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        if (Input.GetKeyDown(KeyCode.LeftControl) && diveCount == 0)
        {
            diveCount = 1;
            playerState = PlayerState.Diving;
            playerAnim.ResetTrigger("jump");
            Debug.Log("dive");
            //playerAnim.SetTrigger("dive");
            isGround = false;

            Quaternion playerYRot = Quaternion.Euler(0f, playerParent.transform.eulerAngles.y, 0f);
            rb.AddForce(playerYRot * new Vector3(0, 10f, diveZ));
            //���� + ���̺��� �ʹ� ���� ���� �ʵ��� y���� ���� ������

        }
        
        if (!isGround && CheckFellDown())
        {
            Debug.Log("Fell Down");
            playerState = PlayerState.Getup;
            playerAnim.ResetTrigger("jump");

        }
    }
    void UpdateDiving()
    {
        if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Dive"))
            playerAnim.SetTrigger("dive");

        //���̺� �ϰ� ���� �� �������� �����ϸ� �ٽ� ȸ�������ֱ�
        /*
        if (isGround && new Vector3(playerParent.transform.eulerAngles.x, 0, playerParent.transform.eulerAngles.z) != Vector3.zero)
        {
            //rotation �ٽ� ������
            playerParent.transform.eulerAngles = Vector3.Lerp(playerParent.transform.eulerAngles, new Vector3(0, playerParent.transform.eulerAngles.y, 0), getUpRotateSpeed * Time.deltaTime);
        }
        */
        //���̺� �ϴ� ���� ȸ�� ����
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        isGround = Physics.Raycast(transform.position, Vector3.down, boxCollider.bounds.extents.y + 0.03f);

        //����||�Ѿ��� ��ȯ
        if (isGround||CheckFellDown())
        {
            Debug.Log("4");
            Debug.Log("Grounded");

            playerAnim.ResetTrigger("dive");
            playerState = PlayerState.Getup;
        }
        /*
        else if (CheckFellDown())
        {
            playerAnim.ResetTrigger("dive");
            playerState = PlayerState.Getup;
        }
        */

    }

    void UpdateGetup()
    {
        //getup �ִϸ��̼� ����
        if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Getup"))
        {
            playerAnim.SetTrigger("getUp");
            bool isGettingUp = false;
        }

        
        if (isGettingUp == false)
        {
            rb.isKinematic = true;
            //playerParent.transform.position = new Vector3(playerParent.transform.position.x, playerParent.transform.position.y + boxCollider.bounds.extents.y, playerParent.transform.position.z);
            isGettingUp = true;
        }

        playerParent.transform.rotation = Quaternion.Euler(new Vector3(0, playerParent.transform.eulerAngles.y, 0));

        //rb.WakeUp();
        //getup �ִϸ��̼��� ������ diveCount=0, idle�� �����ֱ�
        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Getup") && playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            rb.isKinematic = false;
            rb.angularVelocity = Vector3.zero;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                playerState = PlayerState.Move;
            else if (Input.GetKeyDown(KeyCode.Space))
                playerState = PlayerState.Jump;
            else
                playerState = PlayerState.Idle;

            playerAnim.ResetTrigger("getUp");
            Debug.Log("5");
            rb.constraints = RigidbodyConstraints.None;
            diveCount = 0;
            isGettingUp = true;
        }
    }

    void UpdateTripped()
    {
        if (isGround)
        {
            //�Ͼ �� �ֵ��� ���� ������ ȸ��
            Vector3 tmpRot = playerParent.transform.eulerAngles;
            tmpRot.x = 0f;

            playerParent.transform.eulerAngles = Vector3.Slerp(playerParent.transform.eulerAngles, tmpRot, getUpRotateSpeed);

            //getUp���� ��ȯ
            if (playerParent.transform.eulerAngles.x == 0)
                playerState = PlayerState.Getup;
        }
    }

   

    void MovePlayer()
    {
        dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += CameraArm_LJH.camForward;

            playerParent.transform.rotation = Quaternion.Lerp(playerParent.transform.rotation,
              Quaternion.LookRotation(CameraArm_LJH.camForward), rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir += -CameraArm_LJH.camForward;

            playerParent.transform.rotation = Quaternion.Lerp(playerParent.transform.rotation,
              Quaternion.LookRotation(-CameraArm_LJH.camForward), rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D)) //Right
        {
            Vector3 camRight = Quaternion.Euler(0, 90, 0) * CameraArm_LJH.camForward;
            dir += camRight;

            playerParent.transform.rotation = Quaternion.Lerp(playerParent.transform.rotation,
              Quaternion.LookRotation(camRight), rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.A)) //Left
        {
            Vector3 camLeft = Quaternion.Euler(0, -90, 0) * CameraArm_LJH.camForward;
            dir += camLeft;

            playerParent.transform.rotation = Quaternion.Lerp(playerParent.transform.rotation,
                Quaternion.LookRotation(camLeft), rotateSpeed);
        }

        dir.Normalize();
        if (CheckOnSlope())
        { 
            playerParent.transform.position += GetSlopeMoveDirection() * moveSpeed * Time.deltaTime;
        }
        else
        {
            playerParent.transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }

    void MoveRotatePlayer()
    {
        Vector3 heading = CameraArm_LJH.camForward;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir = new Vector3(h, 0, v);

        Quaternion yRot = Quaternion.Euler(0f, mainCamera.transform.eulerAngles.y, 0f);

        dir = yRot * dir;
        dir = playerParent.transform.TransformDirection(dir);
        dir.y = 0;
        dir.Normalize();

        if (!(h == 0 && v == 0))
        {
            playerParent.transform.position += dir * moveSpeed * Time.deltaTime;

            playerParent.transform.rotation = Quaternion.Lerp(playerParent.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);

        }
    }

    float getAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;//Radian to Degree
    }

    bool CheckFellDown()
    {
        /*
        var ray = new Ray(playerParent.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit1, boxCollider.size.x + 0.01f))
        {
            Vector3 floorNormalDir = hit1.normal;
            if (Vector3.Angle(floorNormalDir, playerParent.transform.up) > 80f)
            {
                var ray2 = new Ray(playerParent.transform.position, playerParent.transform.forward);
                bool checkForward = Physics.Raycast(ray2,out RaycastHit forwardHit, boxCollider.bounds.extents.x);
                if (checkForward)
                {
                    if (forwardHit.transform.gameObject.tag == "RespawnPoint")
                        return false;
                }
                bool checkBack = Physics.Raycast(playerParent.transform.position, -playerParent.transform.forward, boxCollider.bounds.extents.x + 0.01f);
                bool checkLeft = Physics.Raycast(playerParent.transform.position, -playerParent.transform.right, boxCollider.bounds.extents.x + 0.01f);
                bool checkRight = Physics.Raycast(playerParent.transform.position, playerParent.transform.right, boxCollider.bounds.extents.x + 0.01f);

                if (checkForward || checkBack || checkLeft || checkRight)
                    return true;
            }

        }
        */

        var ray = new Ray(playerParent.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit1, boxCollider.size.x + 0.01f))
        {
            if (hit1.transform.gameObject.tag != "DontCheckFell")
            {
                Vector3 floorNormalDir = hit1.normal;
                if (Vector3.Angle(floorNormalDir, playerParent.transform.up) > 80f)
                {
                    bool checkForward = Physics.Raycast(playerParent.transform.position, playerParent.transform.forward, boxCollider.bounds.extents.x);
                    bool checkBack = Physics.Raycast(playerParent.transform.position, -playerParent.transform.forward, boxCollider.bounds.extents.x + 0.01f);
                    bool checkLeft = Physics.Raycast(playerParent.transform.position, -playerParent.transform.right, boxCollider.bounds.extents.x + 0.01f);
                    bool checkRight = Physics.Raycast(playerParent.transform.position, playerParent.transform.right, boxCollider.bounds.extents.x + 0.01f);

                    if (checkForward || checkBack || checkLeft || checkRight)
                        return true;
                }
            }

        } 

         


        if (Physics.Raycast(ray, out RaycastHit hit2, boxCollider.size.y + 0.01f))
        {
            if (hit2.transform.gameObject.tag != "DontCheckFell")
            {
                Vector3 floorNormalDir = hit2.normal;
                if (Vector3.Angle(floorNormalDir, playerParent.transform.up) > 90f)
                {
                    return true;
                }
            }

        }
        
        return false;
    }

    private bool CheckOnSlope()
    {
        if (Physics.Raycast(playerParent.transform.position, Vector3.down, out slopeHit, boxCollider.size.y * 0.5f +0.02f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        Vector3 slopeDir = Vector3.ProjectOnPlane(dir, slopeHit.normal).normalized;

        return Vector3.ProjectOnPlane(dir, slopeHit.normal).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            GameObject hitEffect = Instantiate(playerEffects[1]);
            hitEffect.transform.position = collision.GetContact(0).point;
            hitEffect.transform.up = collision.GetContact(0).normal;
            audioSource.clip = PlayerAudioClips_LJH.instance.playerAudioClips[2];
            audioSource.Play();
        }

        
    }
}
