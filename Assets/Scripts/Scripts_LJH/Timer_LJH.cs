using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Timer_LJH : MonoBehaviour
{
    public float currTime;
    public float limitTime = 120;
    public TextMeshProUGUI textTime;
    public GameObject failImage;

    AudioSource audioSource;
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("MapSoundEffect").gameObject.GetComponent<AudioSource>();
        isPlaying = true;
        currTime = 0f;
        textTime.text = (int)limitTime / 60 + " : " + Mathf.Round(limitTime % 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (limitTime < 0.5)
        {
            isPlaying = false;
            //Time.timeScale = 0;
            failImage.SetActive(true);
            audioSource.clip = MapAudioClips_LJH.instance.mapAudioClips[1];
            audioSource.Play();
            //결과 화면으로
            StartCoroutine("IELoadResultScene");
        }
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            if (CanvasManager_skyline_LHE.instance)
            {
                if (CanvasManager_skyline_LHE.instance.isCountFinished)
                {
                    currTime += Time.deltaTime;
                    limitTime -= Time.deltaTime;
                    textTime.text = (int)limitTime / 60 + " : " + Mathf.Round(limitTime % 60);
                }
                
            }

            if (CanvasManager_tundra_LHE.instance)
            {
                if (CanvasManager_tundra_LHE.instance.isCountFinished)
                {
                    currTime += Time.deltaTime;
                    limitTime -= Time.deltaTime;
                    textTime.text = (int)limitTime / 60 + " : " + Mathf.Round(limitTime % 60);
                }
            }

            if (CanvasManager_windmill_LHE.instance)
            {
                if (CanvasManager_windmill_LHE.instance.isCountFinished)
                {
                    currTime += Time.deltaTime;
                    limitTime -= Time.deltaTime;
                    textTime.text = (int)limitTime / 60 + " : " + Mathf.Round(limitTime % 60);
                }
            }
        }
        
    }

    IEnumerator IELoadResultScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Result_LJH");
        yield return null;
    }
    
}
