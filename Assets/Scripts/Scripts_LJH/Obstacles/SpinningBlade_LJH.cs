using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlade_LJH : MonoBehaviour
{
    public float bounciness;

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
