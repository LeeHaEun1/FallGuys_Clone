using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBounce_LHE : MonoBehaviour
{
    public float bounceForce = 400;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody playerRB = collision.rigidbody;
            playerRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5, 5);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
