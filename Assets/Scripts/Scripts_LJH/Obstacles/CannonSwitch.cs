using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSwitch : MonoBehaviour
{
    enum SwitchState
    {
        idle,down,up
    };

    public GameObject cannonStarFactory;

    GameObject torus;
    SwitchState switchState;

    [SerializeField]
    private float minY;

    private Vector3 originPos;
    private Vector3 minPos;
    //스위치는 여기까지만 내려간다

    [SerializeField]
    private float speed = 0.5f;

    public bool isPush;
    public float waitTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        switchState = SwitchState.idle;
        isPush = false;
        torus = transform.parent.transform.GetChild(0).gameObject;
        originPos = transform.position;
        minPos = originPos;
        minPos.y -= minY;
    }

    // Update is called once per frame
    void Update()
    {

        switch (switchState)
        {
            case SwitchState.idle:
                break;

            case SwitchState.down:
                if (isPush)
                {
                    StopCoroutine("IESwitchUp");
                    StartCoroutine("IESwitchDown");
                }
                break;

            case SwitchState.up:
                if (!isPush)
                {
                    StopCoroutine("IESwitchDown");
                    StartCoroutine("IESwitchUp");
                }
                break;
        }
        
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && switchState == SwitchState.idle)
        {
            switchState = SwitchState.down;
            isPush = true;
            print("Switch Collided");
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switchState = SwitchState.up;
            isPush = false;
        }
    }
    */
    IEnumerator IESwitchDown()
    {
        while (transform.position.y > minPos.y)
        {
            Vector3 tmp = transform.position;
            tmp.y -= 0.01f;
            transform.position = tmp;
            yield return new WaitForSeconds(waitTime);
        }

        //다 내려왔으니 쏜다
        GameObject star = Instantiate(cannonStarFactory);
        star.transform.position = torus.transform.position;
        switchState = SwitchState.idle;
    }
    
    IEnumerator IESwitchUp()
    {
        while (transform.position.y < originPos.y)
        {
            //transform.position += transform.up * speed * Time.deltaTime;
            Vector3 tmp = transform.position;
            tmp.y += 0.01f;
            transform.position = tmp;
            yield return new WaitForSeconds(waitTime);
        }
        
        //yield return new WaitForSeconds(waitTime);
        switchState = SwitchState.idle;
    }
    
    //스위치가 다 올라왔을 때 다시 누르고 다시 쏠 수 있게 하고 싶다
}
