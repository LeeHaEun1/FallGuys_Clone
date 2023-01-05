using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioClips_LJH : MonoBehaviour
{
    public static PlayerAudioClips_LJH instance;
    public List<AudioClip> playerAudioClips;

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
