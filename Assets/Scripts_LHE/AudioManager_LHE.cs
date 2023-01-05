using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_LHE : MonoBehaviour
{
    AudioSource audioPlay;

    // Start is called before the first frame update
    void Start()
    {
        audioPlay = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanvasManager_LHE.Instance.state == CanvasManager_LHE.State.Play)
        {
            audioPlay.Play();
        }
    }
}
