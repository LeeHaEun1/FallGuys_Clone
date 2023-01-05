using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlizzardFanMove_LHE : MonoBehaviour
{
    public float speed = 10;
    //Vector3 startPosition;
    GameObject RotationCenter;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //startPosition = transform.position;
        RotationCenter = GameObject.Find("RotationCenter");
        dir = RotationCenter.transform.up;
        print(RotationCenter.transform.position);
        print(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(RotationCenter.transform.position, dir, speed * Time.deltaTime);
    }
}
