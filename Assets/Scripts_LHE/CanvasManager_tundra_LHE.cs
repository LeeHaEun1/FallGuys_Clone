using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using Cinemachine;


// ** skyline���� �̸��ٲٰ� �̹��� ����

// ** ���� ī��Ʈ ���� ��ũ ����

// ** Course�� �ƾ�


public class CanvasManager_tundra_LHE : MonoBehaviour
{
    //public static CanvasManager_LHE Instance;
    public static CanvasManager_tundra_LHE instance;
    //public Canvas loading;
    //public Canvas epicGames;
    //public Canvas start;
    //public Canvas rating;
    //public Canvas play;
    //public Canvas fall;
    public Canvas windmill;
    public Canvas course;
    public Canvas count3;
    public Canvas count2;
    public Canvas count1;
    public Canvas countGO;


    //public CanvasGroup loadingGroup;
    //public CanvasGroup epicGamesGroup;
    //public CanvasGroup startGroup;
    //public CanvasGroup ratingGroup;
    //public CanvasGroup playGroup;
    //public CanvasGroup fallGroup;
    public CanvasGroup windmillGroup;
    public CanvasGroup courseGroup;
    public CanvasGroup count3Group;
    public CanvasGroup count2Group;
    public CanvasGroup count1Group;
    public CanvasGroup countGOGroup;

    // Slider�� �� ������Ʈ�� Slider
    //public Slider loadingSlider;
    //Slider sliderValue;

    // ��� �� ��
    //public Button startButton;
    //public Button playButton;
    //Button startButtonClick;
    //Button playButtonClick;

    // AudioSource ������Ʈ
    //AudioSource startAudio;
    //AudioSource playAudio;
    AudioSource windmillAudio;
    AudioSource courseAudio;
    AudioSource count3Audio;
    AudioSource count2Audio;
    AudioSource count1Audio;
    AudioSource countGOAudio;
    //bgm
    public GameObject BGMManager;
    AudioSource bgmAudio;


    //CutScene
    public GameObject director;
    PlayableDirector pd;
    //public Camera cinemachineCamera;

    //FSM
    public enum State
    {
        //Loading,
        //EpicGames,
        //Start,
        //Rating,
        //Play,
        //Fall,
        Windmill,
        Course,
        Count3,
        Count2,
        Count1,
        CountGO,
        Exit
    }
    public State state;

    public float currentTime = 0;
    public float changeTime = 20;
    public float cutsceneTime = 30;
    public float countDownTime = 15;


    public bool isCountFinished;
    public bool isCutSceneFinished;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isCutSceneFinished = false;
        isCountFinished = false;
        //epicGamesGroup.alpha = 0;
        //startGroup.alpha = 0;
        //ratingGroup.alpha = 0;
        //playGroup.alpha = 0;
        //fallGroup.alpha = 0;
        windmillGroup.alpha = 0;
        courseGroup.alpha = 0;
        count3Group.alpha = 0;
        count2Group.alpha = 0;
        count1Group.alpha = 0;
        countGOGroup.alpha = 0;

        // ��ư ������ ȭ��鿡�� ���¸ӽ� �����Ű�� ���� �߰�
        //rating.enabled = false;
        //fall.enabled = false;

        // Start��ư �� ������ ���� �ذ� ���� �߰�
        //loading.enabled = false;
        //epicGames.enabled = false;
        //start.enabled = false;
        //play.enabled = false;
        windmill.enabled = false;
        course.enabled = false;
        count3.enabled = false;
        count2.enabled = false;
        count1.enabled = false;
        countGO.enabled = false;
        

        state = State.Windmill;
                

        //sliderValue = loadingSlider.GetComponent<Slider>();
        //startButtonClick = startButton.GetComponent<Button>();
        //playButtonClick = playButton.GetComponent<Button>();

        //���� ������ ĵ�������� Audio Source ������Ʈ ��������
        //startAudio = start.gameObject.GetComponent<AudioSource>();
        //playAudio = play.gameObject.GetComponent<AudioSource>();
        windmillAudio = windmill.gameObject.GetComponent<AudioSource>();
        courseAudio = course.gameObject.GetComponent<AudioSource>();
        count3Audio = count3.gameObject.GetComponent<AudioSource>();
        count2Audio = count2.gameObject.GetComponent<AudioSource>();
        count1Audio = count1.gameObject.GetComponent<AudioSource>();
        countGOAudio = countGO.gameObject.GetComponent<AudioSource>();
        //bgm
        bgmAudio = BGMManager.gameObject.GetComponent<AudioSource>();

        // ����� Ʋ���ְ� ����(state ���� ������ ����)
        windmillAudio.Play();


        // CutScene
        pd = director.GetComponent<PlayableDirector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (state == State.Loading)
        //{
        //    UpdateLoading();
        //}
        //if (state == State.EpicGames)
        //{
        //    UpdateEpicGames();
        //}
        //if (state == State.Start)
        //{
        //    UpdateStart();
        //}
        //if (state == State.Rating)
        //{
        //    UpdateRating();
        //}
        //if (state == State.Play)
        //{
        //    UpdatePlay();
        //}
        //if (state == State.Fall)
        //{
        //    UpdateFall();
        //}
        if (state == State.Windmill)
        {
            UpdateWindmill();
        }
        if (state == State.Course)
        {
            UpdateCourse();
        }
        if (state == State.Count3)
        {
            UpdateCount3();
        }
        if (state == State.Count2)
        {
            UpdateCount2();
        }
        if (state == State.Count1)
        {
            UpdateCount1();
        }
        if (state == State.CountGO)
        {
            UpdateCountGO();
        }
        if (state == State.Exit)
        {
            UpdateExit();
        }
    }


    //private void UpdateLoading()
    //{
    //    loadingGroup.alpha = 1;
    //    loading.enabled = true;

    //    if (sliderValue.value >= 1)
    //    {
    //        loadingGroup.alpha = 0;
    //        loading.enabled = false;

    //        //epicGamesGroup.alpha = Mathf.Lerp(0, 1, Time.deltaTime);
    //        epicGamesGroup.alpha = 1;
    //        epicGames.enabled = true;

    //        state = State.EpicGames;
    //    }
    //}

    //private void UpdateEpicGames()
    //{
    //    currentTime += Time.fixedDeltaTime;
    //    if (currentTime >= changeTime)
    //    {
    //        epicGamesGroup.alpha = 0;
    //        epicGames.enabled = false;

    //        startGroup.alpha = 1;
    //        start.enabled = true;

    //        startAudio.Play();
    //        state = State.Start;

    //        currentTime = 0;
    //    }
    //}

    //private void UpdateStart()
    //{
    //    Cursor.visible = true;
    //    startGroup.alpha = 1;
    //    start.enabled = true;
    //    if (rating.enabled == true)
    //    {
    //        ratingGroup.alpha = 1;

    //        startGroup.alpha = 0;
    //        start.enabled = false;

    //        startAudio.mute = true;

    //        state = State.Rating;
    //    }
    //}


    //private void UpdateRating()
    //{
    //    currentTime += Time.fixedDeltaTime;
    //    if (currentTime >= changeTime)
    //    {
    //        ratingGroup.alpha = 0;
    //        rating.enabled = false;

    //        playGroup.alpha = 1;
    //        play.enabled = true;

    //        // **���⼭ Ʋ����� �ǵ��� ������ ����ȴ�,, �������� �𸣰��� -> ���� Ȯ�� �� ����
    //        playAudio.Play();
    //        state = State.Play;

    //        currentTime = 0;
    //    }
    //}

    //private void UpdatePlay()
    //{
    //    Cursor.visible = true;
    //    playGroup.alpha = 1;
    //    play.enabled = true;
    //    // playAudio.Play(); ���� ��� �ڵ� �������� ����

    //    if (fall.enabled == true)
    //    {
    //        fallGroup.alpha = 1;

    //        playGroup.alpha = 0;
    //        play.enabled = false;

    //        state = State.Fall;
    //    }
    //}

    //private void UpdateFall()
    //{
    //    currentTime += Time.fixedDeltaTime;
    //    if (currentTime >= changeTime)
    //    {
    //        fallGroup.alpha = 0;
    //        fall.enabled = false;

    //        windmillGroup.alpha = 1;
    //        windmill.enabled = true;

    //        // Audio
    //        playAudio.mute = true;
    //        windmillAudio.Play();

    //        state = State.Windmill;

    //        currentTime = 0;
    //    }
    //}

    private void UpdateWindmill()
    {
        // windmillAudio.Play();

        windmillGroup.alpha = 1;
        windmill.enabled = true;

        currentTime += Time.fixedDeltaTime;
        if (currentTime >= changeTime)
        {
            windmillGroup.alpha = 0;
            windmill.enabled = false;

            courseGroup.alpha = 1;
            course.enabled = true;

            windmillAudio.mute = true;
            courseAudio.Play();

            state = State.Course;

            currentTime = 0;
        }
    }

    // CutScene ��� ����
    private void UpdateCourse()
    {
        // �ƾ� ���
        pd.Play();
       
        currentTime += Time.fixedDeltaTime;
        
        // �ƾ� �����ִ� ���� �ߴ� UI -> ���� �ƾ� �ð��� ���� ��
        // pd.duration �����ϸ� ��ũ �ȸ���,,,
        if(currentTime >= cutsceneTime)
        {
            isCutSceneFinished = true;

            courseGroup.alpha = 0;
            course.enabled = false;

            count3Group.alpha = 1;
            count3.enabled = true;

            courseAudio.mute = true;
            count3Audio.Play();

            // �ó׸ӽ� ī�޶�� ���� ĵ���� �̵�
            GameObject cinemachineGroup = GameObject.Find("Cinemachine");
            cinemachineGroup.gameObject.SetActive(false);

            state = State.Count3;

            currentTime = 0;
        }
    }

    private void UpdateCount3()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= countDownTime)
        {
            count3Group.alpha = 0;
            count3.enabled = false;

            count2Group.alpha = 1;
            count2.enabled = true;

            count3Audio.mute = true;
            count2Audio.Play();

            state = State.Count2;

            currentTime = 0;
        }
    }

    private void UpdateCount2()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= countDownTime)
        {
            count2Group.alpha = 0;
            count2.enabled = false;

            count1Group.alpha = 1;
            count1.enabled = true;

            count2Audio.mute = true;
            count1Audio.Play();

            state = State.Count1;

            currentTime = 0;
        }
    }

    private void UpdateCount1()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= countDownTime)
        {
            count1Group.alpha = 0;
            count1.enabled = false;

            countGOGroup.alpha = 1;
            countGO.enabled = true;

            count1Audio.mute = true;
            countGOAudio.Play();

            state = State.CountGO;
            // bgm -> ���� �־���� ���� Ÿ�̹��� ����
            bgmAudio.Play();

            currentTime = 0;
        }
    }

    private void UpdateCountGO()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= countDownTime)
        {
            countGOGroup.alpha = 0;
            countGO.enabled = false;
            isCountFinished = true;
            countGOAudio.mute = true;

            state = State.Exit;


            currentTime = 0;
        }
    }

    private void UpdateExit()
    {
        //GameObject cinemachineGroup = GameObject.Find("Cinemachine");
        //cinemachineGroup.gameObject.SetActive(false);
    }
}
