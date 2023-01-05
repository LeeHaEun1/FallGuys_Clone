using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRod_LJH : MonoBehaviour
{
    enum LightRodState
    {
        up,down
    };

    LightRodState lightRodState;
    bool isMoving;

    public List<Transform> lightRodPos;
    public float speed = 0.5f;
    public float waitTime = 2f;
    //[0] = UpPos, [1] = DownPos

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        lightRodState = LightRodState.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager_tundra_LHE.instance.isCutSceneFinished)
        {
            switch (lightRodState)
            {
                case (LightRodState.down):
                    if (!isMoving)
                    {
                        StartCoroutine("IELightRodDown");
                    }
                    break;
                case (LightRodState.up):
                    if (!isMoving)
                    {
                        StartCoroutine("IELightRodUp");
                    }
                    break;

            }
        }
    }

    IEnumerator IELightRodDown()
    {
        isMoving = true;

        while (transform.position.y >= lightRodPos[1].position.y)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(waitTime);

        isMoving = false;
        lightRodState = LightRodState.up;

        yield return null;
    }

    IEnumerator IELightRodUp()
    {
        isMoving = true;

        while (transform.position.y <= lightRodPos[0].position.y)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(waitTime);

        isMoving = false;
        lightRodState = LightRodState.down;

        yield return null;
    }
}
