using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBeamsRotate : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation += Quaternion.Euler(new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y+(speed*Time.deltaTime),transform.localEulerAngles.z));
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (speed * Time.deltaTime), transform.localEulerAngles.z);
    }
}
