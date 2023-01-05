using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityZone : MonoBehaviour
{
    public float jumpPower = 1000f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInfo_LJH.instance.jumpPower = jumpPower;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInfo_LJH.instance.jumpPower = jumpPower;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInfo_LJH.instance.jumpPower = PlayerInfo_LJH.instance.originJumpPower;
        }
    }
}
