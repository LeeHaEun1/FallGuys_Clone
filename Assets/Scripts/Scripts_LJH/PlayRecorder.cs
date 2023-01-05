using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayRecorder : MonoBehaviour
{
    Timer_merged timer;
    AudioSource audioSource;
    public List<AudioClip> audioClips;
    //0 = jump, 1 = qualified, 2 = eliminated

    public GameObject successImage;
    public float waitSec = 3f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("MapSoundEffect").gameObject.GetComponent<AudioSource>();

        timer = GameObject.FindGameObjectWithTag("Timer").gameObject.GetComponent<Timer_merged>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Record_LJH.instance.recordSecs.Add(timer.currTime);
            //Time.timeScale = 0;
            successImage.SetActive(true);
            audioSource.clip = MapAudioClips_LJH.instance.mapAudioClips[0];
            audioSource.Play();
            //다음 스테이지로
            //Invoke("LoadNextMap", waitSec);
            StartCoroutine("IELoadNextMap");
        }
    }

    IEnumerator IELoadNextMap()
    {
        if (GameManager_LJH.instance.count < GameManager_LJH.instance.sceneList.Count)//3이면 진입 못 함
        {
            yield return new WaitForSeconds(3f);
            GameManager_LJH.instance.count += 1; //1->2, 2->3
            SceneManager.LoadScene(GameManager_LJH.instance.sceneList[GameManager_LJH.instance.count - 1]); //2이면 1, 3이면 2
        }
        else
        {
            GameManager_LJH.instance.count = 1;
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Result_LJH");
        }
        yield return null;
    }

    
    
}
