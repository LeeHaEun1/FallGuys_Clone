using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldSwitch_LJH : MonoBehaviour
{
    public GameObject forceFieldButton;
    public List<GameObject> walls;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("MapSoundEffect").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("TriggerEnter");
            StopCoroutine("IESwitchUp");
            StartCoroutine("IESwitchDown");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("TriggerExit");
            StopCoroutine("IESwitchDown");
            StartCoroutine("IESwitchUp");
        }
    }

    IEnumerator IESwitchDown()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 tmp = forceFieldButton.transform.position;
            tmp.y -= 0.01f;
            forceFieldButton.transform.position = tmp;
            yield return new WaitForSeconds(0.05f);
        }

        //다 내려왔으니 바꾼다
        for(int i = 0; i < walls.Count; i++)
        {
            if (!walls[i].activeSelf)
                walls[i].SetActive(true);
            else
                walls[i].SetActive(false);
        }

        audioSource.clip = MapAudioClips_LJH.instance.skylineAudioClips[1];
        audioSource.Play();

        yield return null;
    }

    IEnumerator IESwitchUp()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 tmp = forceFieldButton.transform.position;
            tmp.y += 0.01f;
            forceFieldButton.transform.position = tmp;
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }

}
