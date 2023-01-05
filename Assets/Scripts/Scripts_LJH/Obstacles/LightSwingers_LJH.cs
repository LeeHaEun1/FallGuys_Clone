using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwingers_LJH : MonoBehaviour
{
    public float angle = 0;

    private float currTime = 0;

    [SerializeField]
    private float speed = 2f;

    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        print(gameObject.name + ", forward : " + transform.forward);
        print(gameObject.name + ", right : " + transform.right);
        print(gameObject.name + ", up : " + transform.up);
        //dir = Quaternion.Euler(transform.eulerAngles) * Vector3.up;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager_tundra_LHE.instance.isCutSceneFinished)
        {
            currTime += Time.deltaTime * speed;
            transform.rotation = CalculateRotationOfLightSwingers();
        }
    }
    //forward를 현재 rotation만큼 돌려준다
    //이 forward로 transform 의 rotation을 lerp시킨다
    Quaternion CalculateRotationOfLightSwingers()
    {
        return Quaternion.Lerp(Quaternion.Euler(new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,-angle)),Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle)),GetLerpTime());
        //return Quaternion.Lerp(Quaternion.Euler(transform.forward * angle), Quaternion.Euler(-transform.forward * angle), GetLerpTime());
    }

    float GetLerpTime()
    {
        return (Mathf.Sin(currTime) + 1) * 0.5f;
    }

}
