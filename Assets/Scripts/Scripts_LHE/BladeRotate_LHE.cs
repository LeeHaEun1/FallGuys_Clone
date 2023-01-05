using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotate_LHE : MonoBehaviour
{
    public float speed = 150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager_windmill_LHE.instance.isCutSceneFinished)
            transform.Rotate(transform.forward * speed * Time.deltaTime);
    }

    // Arms-Player 충돌 시 Arm 움직이는 현상 => Anchor 조절 및 Is Kinematic 체크로 해결
}
