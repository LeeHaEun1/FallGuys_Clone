using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlizzardFanTorusRotate_LHE : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float period = 2;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, speed * Time.fixedDeltaTime, 0);

        //float x = amplitude * Mathf.Sin(Time.time * period);
        //transform.position += Vector3.right * x * speed * Time.fixedDeltaTime;
    }
}
