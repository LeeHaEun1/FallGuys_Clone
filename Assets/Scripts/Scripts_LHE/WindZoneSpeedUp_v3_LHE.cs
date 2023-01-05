using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneSpeedUp_v3_LHE : MonoBehaviour
{
    Rigidbody playerRB;
    public GameObject player;
    public float windPower = 20;

    public float moveSpeedUp = 10f;
    public float moveSpeedDown = 2.5f;

    private void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Enter UP Windzone");

            playerRB.AddForce(transform.forward * windPower);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedUp;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedDown;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Stay UP Windzone");

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedUp;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedDown;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Exit UP Windzone");

            playerRB.velocity = Vector3.zero;
            PlayerInfo_LHE.Instance.moveSpeed = PlayerInfo_LHE.Instance.originMoveSpeed;
        }
    }   
}
