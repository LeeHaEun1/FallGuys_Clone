using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_LJH : MonoBehaviour
{
    public float bounciness;

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
        if (collision.gameObject.tag == "player")
        {
            BoxCollider playerCol = collision.gameObject.GetComponent<BoxCollider>();
            playerCol.material.bounciness = bounciness;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            BoxCollider playerCol = collision.gameObject.GetComponent<BoxCollider>();
            playerCol.material.bounciness = 0.2f;
        }
    }
}
