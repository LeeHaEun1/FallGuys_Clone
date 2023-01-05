using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneSpeedDown_LHE : MonoBehaviour
{
    Rigidbody playerRB;
    public GameObject player;

    public float windPower = 20;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("player enter windzone");
            playerRB.AddForce(transform.forward * windPower);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("player exit windzone");
            playerRB.velocity = Vector3.zero;
        }
    }
}
