using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScroll_LJH : MonoBehaviour
{
    Material mat;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += new Vector2(0f, 1f) * speed * Time.deltaTime;
    }
}
