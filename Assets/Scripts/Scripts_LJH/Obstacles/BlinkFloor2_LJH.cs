using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkFloor2_LJH : MonoBehaviour
{
    public float waitTime;
    public List<GameObject> blinkFloors;
    bool check = false;

    private void Update()
    {
        if (!check)
        {
            StartCoroutine("IESetActive");
        }
    }

    IEnumerator IESetActive()
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < blinkFloors.Count; i++)
            blinkFloors[i].SetActive(true);
        yield return null;
    }
}
