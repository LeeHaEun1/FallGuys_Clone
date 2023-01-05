using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAudioClips_LJH : MonoBehaviour
{
    public static MapAudioClips_LJH instance;
    public List<AudioClip> mapAudioClips;
    public List<AudioClip> skylineAudioClips;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
