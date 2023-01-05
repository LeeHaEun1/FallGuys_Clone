using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo_LJH : MonoBehaviour
{
    public static PlayerInfo_LJH instance = null;

    public float jumpPower = 200f;
    public Vector3 respawnPosition;
    public float originJumpPower;

    private void Awake()
    {
        originJumpPower = jumpPower;

        if (instance == null)
        {
            //ù �� ������ ���� �ν��Ͻ� �ʱ�ȭ
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
