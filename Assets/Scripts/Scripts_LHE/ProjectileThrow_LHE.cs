using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 발사시간이 되면 ball을 내 위치로 가져와서 방향을 일치시키고 forward방향으로 발사하고 싶다
public class ProjectileThrow_LHE : MonoBehaviour
{
    float currentTime = 0;
    public float createTime = 1.5f;
    public GameObject ballFactory;

    // 오디오, 이펙트
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

                //이펙트, 오디오
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
