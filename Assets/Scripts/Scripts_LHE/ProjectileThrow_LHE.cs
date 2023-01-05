using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �߻�ð��� �Ǹ� ball�� �� ��ġ�� �����ͼ� ������ ��ġ��Ű�� forward�������� �߻��ϰ� �ʹ�
public class ProjectileThrow_LHE : MonoBehaviour
{
    float currentTime = 0;
    public float createTime = 1.5f;
    public GameObject ballFactory;

    // �����, ����Ʈ
    public GameObject explosionFactory;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            currentTime += Time.deltaTime;
            if (currentTime > createTime)
            {
                GameObject ball = Instantiate(ballFactory);
                ball.transform.position = transform.position;
                ball.transform.forward = transform.forward;

                //����Ʈ, �����
                GameObject explosion = Instantiate(explosionFactory);
                explosion.transform.position = transform.position;
                explosion.transform.forward = transform.forward;

                currentTime = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        //currentTime += Time.fixedDeltaTime;
        //if (currentTime > createTime)
        //{
        //    GameObject ball = Instantiate(ballFactory);
        //    ball.transform.position = transform.position;
        //    ball.transform.forward = transform.forward;
        //    currentTime = 0;
        //}
    }
}
