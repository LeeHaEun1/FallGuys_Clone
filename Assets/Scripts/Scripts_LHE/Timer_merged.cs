using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer_merged : MonoBehaviour
{
    public float currTime;
    float currCheckTime;
    public float limitTime = 180;
    public TextMeshProUGUI textTime;
    public GameObject failImage;
    bool isPlaying;
    public float timeMultiplier = 50;


    // Start is called before the first frame update
    void Start()
    {
        
        isPlaying = true;
        currTime = 0f;
        currCheckTime = currTime;
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


            //결과 화면으로
            StartCoroutine("IELoadResultScene");
        }
    }

    private void FixedUpdate()
    {
        if (CanvasManager_windmill_LHE.instance)
        {
            if (CanvasManager_windmill_LHE.instance.isCountFinished)
            {
                currTime += Time.fixedDeltaTime;
                currCheckTime += Time.fixedDeltaTime;
                if (currCheckTime > Time.fixedDeltaTime * timeMultiplier)
                {
                    limitTime -= 1;
                    textTime.text = (int)limitTime / 60 + " : " + Mathf.Round(limitTime % 60);
                    currCheckTime = 0f;
                }
            }
        }

        if (CanvasManager_tundra_LHE.instance)
        {
            if (CanvasManager_tundra_LHE.instance.isCountFinished)
            {
                currTime += Time.fixedDeltaTime;
                currCheckTime += Time.fixedDeltaTime;
                if (currCheckTime > Time.fixedDeltaTime * timeMultiplier)
                {
                    limitTime -= 1;
                    currCheckTime = 0f;
                    textTime.text = (int)limitTime / 60 + " : " + Mathf.Round(limitTime % 60);
                }
            }
        }

        if (CanvasManager_skyline_LHE.instance)
        {
            if (CanvasManager_skyline_LHE.instance.isCountFinished)
            {
                currTime += Time.fixedDeltaTime;
                currCheckTime += Time.fixedDeltaTime;
                if (currCheckTime > Time.fixedDeltaTime * timeMultiplier)
                {
                    limitTime -= 1;
                    currCheckTime = 0f;
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
