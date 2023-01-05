using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_LJH : MonoBehaviour
{
    public static GameManager_LJH instance;
    public List<string> sceneList;
    public int count;
    //로드할 씬 번호
    // Start is called before the first frame update
    void Start()
    {
        sceneList.Add("Map1");
        sceneList.Add("TundraRunMap_LHE");
        sceneList.Add("SkylineStumble_LJH");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        count = 1;
        //골인 시 두 번째 맵부터 로드하므로

        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            //첫 씬 시작할 때에 인스턴스 초기화
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
