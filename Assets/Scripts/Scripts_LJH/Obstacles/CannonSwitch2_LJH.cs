using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSwitch2_LJH : MonoBehaviour
{
    public GameObject cannonStarFactory;
    public float minY = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - minY, transform.position.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + minY, transform.position.z);
        }
    }
}
