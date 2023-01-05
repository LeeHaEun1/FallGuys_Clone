using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRotate_LHE : MonoBehaviour
{
    public float speed = 150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager_windmill_LHE.instance.isCutSceneFinished)
            transform.Rotate(transform.up * speed * Time.deltaTime);
    }    
}
