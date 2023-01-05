using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_CylinderRotate_Lhe1 : MonoBehaviour
{
    public float speed = 10;
    //CapsuleCollider cc;
    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationCenter = new Vector3(transform.position.x+0.9f, transform.position.y-0.6f, transform.position.z);
        //print("position: " + transform.position);
        //print("center: " + rotationCenter);
        transform.RotateAround(rotationCenter, Vector3.up, speed * Time.deltaTime);
    }
}
