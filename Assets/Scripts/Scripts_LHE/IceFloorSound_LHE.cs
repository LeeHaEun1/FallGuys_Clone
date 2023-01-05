using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloorSound_LHE : MonoBehaviour
{
    AudioSource iceCrack;

    private void Start()
    {
        iceCrack = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Enter Ice");
            iceCrack.Play();
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        print("Stay Ice");
    //        iceCrack.Play();
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Exit Ice");
            iceCrack.mute = true;
        }
    }
}
