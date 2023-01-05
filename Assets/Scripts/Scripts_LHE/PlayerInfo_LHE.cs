using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo_LHE : MonoBehaviour
{
    public static PlayerInfo_LHE Instance = null;

    public float moveSpeed = 5f;
    public float originMoveSpeed;

    private void Awake()
    {
        originMoveSpeed = moveSpeed;

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }  
}
