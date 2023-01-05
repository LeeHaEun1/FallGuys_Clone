using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAnim_LJH : MonoBehaviour
{
    float time = 0;
    public float size = 3;
    public float upSizeTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= upSizeTime)
        {
            transform.localScale = Vector3.one * (1 + size * time);
        }
        else if (time <= upSizeTime * 2)
        {
            transform.localScale = Vector3.one * (2 * size * upSizeTime + 1 - time * size);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        time += Time.unscaledDeltaTime;
    }
}
