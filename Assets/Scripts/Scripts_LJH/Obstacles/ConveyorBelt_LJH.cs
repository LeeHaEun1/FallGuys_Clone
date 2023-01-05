using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt_LJH : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    public List<GameObject> onBelt;

    // Start is called before the first frame update
    void Start()
    {
        dir = gameObject.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<= onBelt.Count - 1; i++)
        {
            //onBelt[i].GetComponent<Rigidbody>().velocity = speed * dir * Time.deltaTime;
            onBelt[i].transform.position = onBelt[i].transform.position + gameObject.transform.forward * speed * Time.deltaTime;
        }
    }

    //컨베이어 벨트와 충돌 시
    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    //컨베이어 벨트를 빠져나갈 시
    private void OnCollisionExit(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
    }
}
