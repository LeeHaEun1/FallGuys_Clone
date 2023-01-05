using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippityBippityUpMirror_LJH : MonoBehaviour
{
    enum FlippityRotateState
    {
        stop, left, right
    };

    FlippityRotateState flippityRotateState;
    float currTime;
    public float rotTime = 2f;
    public int rotAngle = 10;
    public GameObject parentOfThis;
    Vector3 dir;
    bool isRotating;

    // Start is called before the first frame update
    void Start()
    {
        flippityRotateState = FlippityRotateState.right;
        currTime = 0f;
        //dir = transform.right;
        dir = parentOfThis.transform.right;
        print(dir);
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        currTime += Time.deltaTime;
        if (currTime > rotTime && flippityRotateState != FlippityRotateState.right)
        {
            flippityRotateState = FlippityRotateState.right;
            StartCoroutine("IERotateRight");
        }
        */
        if (CanvasManager_tundra_LHE.instance.isCutSceneFinished)
        {
            switch (flippityRotateState)
            {
                case (FlippityRotateState.right):
                    if (!isRotating)
                    {
                        StopCoroutine("IERotateLeft");
                        StartCoroutine("IERotateRight");
                    }
                    break;

                case (FlippityRotateState.left):
                    if (!isRotating)
                    {
                        StopCoroutine("IERotateRight");
                        StartCoroutine("IERotateLeft");
                    }
                    break;

            }
        }

    }

    IEnumerator IERotateRight()
    {
        isRotating = true;
        for (int i = 0; i <= rotAngle; i++)
        {
            dir = Quaternion.Euler(0, 0, i) * dir;
            //transform.right = dir;
            parentOfThis.transform.right = dir;
            yield return new WaitForSeconds(0.05f);
        }
        currTime = 0;

        yield return new WaitForSeconds(rotTime);
        isRotating = false;
        flippityRotateState = FlippityRotateState.left;
    }

    IEnumerator IERotateLeft()
    {
        isRotating = true;
        for (int i = 0; i >= -rotAngle; i--)
        {
            dir = Quaternion.Euler(0, 0, i) * dir;
            //transform.right = dir;
            parentOfThis.transform.right = dir;
            yield return new WaitForSeconds(0.05f);
        }
        currTime = 0;
        yield return new WaitForSeconds(rotTime);

        flippityRotateState = FlippityRotateState.right;
        isRotating = false;
    }
}
