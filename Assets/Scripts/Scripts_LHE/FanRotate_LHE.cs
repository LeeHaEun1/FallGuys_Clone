using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate_LHE : MonoBehaviour
{

    public float speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager_windmill_LHE.instance.isCutSceneFinished)
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
