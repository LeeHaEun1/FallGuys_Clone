using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow_LJH : MonoBehaviour
{
    public Transform target;
    public GameObject camPos;
    public float followSpeed = 2f;
    public float offsetY = 1f;
    public float offsetZ = -1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, target.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, camPos.transform.position, followSpeed * Time.deltaTime);
    }
}
