using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutBumperFootMove_LHE : MonoBehaviour
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
        //float x = amplitude * Mathf.Sin(Time.time * period);
        ////Vector3 dir = new Vector3(x, 0, 0);
        ////transform.position += dir * speed * Time.deltaTime;q
        //transform.position += transform.right * x * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (CanvasManager_tundra_LHE.instance.state == CanvasManager_tundra_LHE.State.Exit)
        {
            float x = amplitude * Mathf.Sin(Time.time * period);
            transform.position += transform.right * x * speed * Time.fixedDeltaTime;
        }
    }
}
