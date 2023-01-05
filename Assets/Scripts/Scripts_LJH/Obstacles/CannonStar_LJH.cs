using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStar_LJH : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float addPowerUp;
    [SerializeField]
    private float addPowerForward;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Quaternion starYRot = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        rb.AddForce(starYRot * new Vector3(0, addPowerUp, addPowerForward));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
