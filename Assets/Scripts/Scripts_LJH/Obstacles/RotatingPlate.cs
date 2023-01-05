using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlate : MonoBehaviour
{
    public float speed;
    public List<GameObject> onBlade = new List<GameObject>();

    void Update()
    {
        transform.Rotate(transform.up * speed * Time.deltaTime);

        for (int i = 0; i <= onBlade.Count - 1; i++)
        {
            onBlade[i].transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        print("collision");
        onBlade.Add(collision.gameObject);
        
    }

    
    private void OnCollisionExit(Collision collision)
    {
        onBlade.Remove(collision.gameObject);
    }
    
}
