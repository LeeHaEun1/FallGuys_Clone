using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneSpeedUp_LHE : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CapsuleMove_LHE cm = other.GetComponent<CapsuleMove_LHE>();
        if (cm)
        {
            cm.speed = cm.speed * 1.3f;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        CapsuleMove_LHE cm = other.GetComponent<CapsuleMove_LHE>();
        if (cm)
        {
            cm.speed = 5;
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
