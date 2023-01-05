using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger_LJH : MonoBehaviour
{
    public GameObject cannonSwitch;
    public GameObject cannonStarFactory;
    public GameObject torus;

    [SerializeField]
    private float minY;

    private Vector3 originPos;
    AudioSource audioSource;

    public GameObject starPoint;
    private void Start()
    {
        audioSource= GetComponent<AudioSource>();
        print("forward : "+torus.transform.forward);
        print("right : "+torus.transform.right);
        print("up : " + torus.transform.up);
        originPos = cannonSwitch.transform.position;
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
            Vector3 tmp = cannonSwitch.transform.position;
            tmp.y -= 0.01f;
            cannonSwitch.transform.position = tmp;
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.clip = MapAudioClips_LJH.instance.skylineAudioClips[1];
        audioSource.Play();
        yield return new WaitForSeconds(0.7f);
        //다 내려왔으니 쏜다
        GameObject star = Instantiate(cannonStarFactory);
        audioSource.clip = MapAudioClips_LJH.instance.skylineAudioClips[0];
        audioSource.Play();
        star.transform.position = starPoint.transform.position;
        star.transform.forward = torus.transform.up;
        yield return null;
    }

    IEnumerator IESwitchUp()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 tmp = cannonSwitch.transform.position;
            tmp.y += 0.01f;
            cannonSwitch.transform.position = tmp;
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }

    //스위치가 다 올라왔을 때 다시 누르고 다시 쏠 수 있게 하고 싶다
}
