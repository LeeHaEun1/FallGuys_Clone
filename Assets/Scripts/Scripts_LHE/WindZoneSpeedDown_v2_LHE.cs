using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneSpeedDown_v2_LHE : MonoBehaviour
{
    public float moveSpeedUp = 10f;
    public float moveSpeedDown = 2.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Enter DOWN Windzone");

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedDown;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedUp;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Stay DOWN Windzone");

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedDown;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                PlayerInfo_LHE.Instance.moveSpeed = moveSpeedUp;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Exit DOWN Windzone");

            PlayerInfo_LHE.Instance.moveSpeed = PlayerInfo_LHE.Instance.originMoveSpeed;
        }
    }

}
