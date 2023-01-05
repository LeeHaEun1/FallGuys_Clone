using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkFloor_LJH : MonoBehaviour
{
    public enum BlinkFloorState
    {
        increase, decrease
    };

    public BlinkFloorState blinkFloorState;
    public List<Transform> blinkFloorSize;
    public float waitTime = 2f;
    public float changeTime = 0.005f;
    public float moveSpeed = 5f;
    public float scaleSpeed = 5f;
    bool isChanging;
    //[0] = max size, [1] = min size

    // Start is called before the first frame update
    void Start()
    {
        isChanging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager_tundra_LHE.instance.isCutSceneFinished)
        {
            switch (blinkFloorState)
            {
                case BlinkFloorState.increase:
                    StopCoroutine("IEDecreasing");
                    StartCoroutine("IEIncreasing");

                    break;

                case BlinkFloorState.decrease:
                    StopCoroutine("IEIncreasing");
                    StartCoroutine("IEDecreasing");

                    break;
            }
        }
    }

    IEnumerator IEIncreasing()
    {
        //isChanging = true;

        Vector3 tmpScale = transform.localScale;
        tmpScale.z = Mathf.Lerp(transform.localScale.z, blinkFloorSize[0].localScale.z, scaleSpeed * Time.deltaTime);
        transform.localScale = tmpScale;

        Vector3 tmpPos = transform.localPosition;
        tmpPos.z = Mathf.Lerp(transform.localPosition.z, -62f, scaleSpeed * Time.deltaTime);
        transform.localPosition = tmpPos;
        /*
        while (transform.localScale.z <= blinkFloorSize[0].localScale.z)
        {
            Vector3 tmpSize = transform.localScale;
            tmpSize.z += 0.1f;
            transform.localScale = tmpSize;

            //Vector3 tmpPos = transform.position;
            //tmpPos.z += 0.05f;
            //transform.position = tmpPos;
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;
            yield return new WaitForSeconds(changeTime);
        }
        */
        if (transform.localScale.z >= 18.5f)
        {
            yield return new WaitForSeconds(waitTime);
            print("increase to decrease");
            isChanging = false;
            blinkFloorState = BlinkFloorState.decrease;

            yield return null;
        }
    }

    IEnumerator IEDecreasing()
    {
        //isChanging = true;
        
        Vector3 tmpScale = transform.localScale;
        tmpScale.z = Mathf.Lerp(transform.localScale.z, blinkFloorSize[1].localScale.z, scaleSpeed * Time.deltaTime);
        transform.localScale = tmpScale;

        //Vector3 tmpSize = transform.localScale;
        //tmpSize.z -= 0.1f;
        //transform.localScale = tmpSize;

        Vector3 tmpPos = transform.localPosition;
        tmpPos.z = Mathf.Lerp(transform.localPosition.z, -66f,scaleSpeed*Time.deltaTime);
        transform.localPosition = tmpPos;

        //transform.position += -transform.forward * moveSpeed * Time.deltaTime;
        //yield return new WaitForSeconds(changeTime);
        if (transform.localScale.z <= 0.17f)
        {
            yield return new WaitForSeconds(waitTime);
            print("decrease to increase");
            isChanging = false;
            blinkFloorState = BlinkFloorState.increase;

            yield return null;
        }
    }
}
