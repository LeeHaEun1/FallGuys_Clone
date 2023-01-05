using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyFloor_LJH : MonoBehaviour
{
    GameObject playerParent;
    GameObject player;

    PlayerMove_merged playerMove;

    [SerializeField]
    float movePower;

    // Start is called before the first frame update
    void Start()
    {
        playerParent = GameObject.Find("PlayerParent");
        player = playerParent.transform.GetChild(0).gameObject;
        playerMove = player.GetComponent<PlayerMove_merged>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerMove.playerState == PlayerMove_merged.PlayerState.Move)
            {
                print("move add force");
                playerMove.rb.AddForce(playerParent.transform.forward * movePower);
            }
        }
    }
}
