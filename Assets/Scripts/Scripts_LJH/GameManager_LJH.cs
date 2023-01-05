using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_LJH : MonoBehaviour
{
    public static GameManager_LJH instance;
    public List<string> sceneList;
    public int count;
    //�ε��� �� ��ȣ
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
        //���� �� �� ��° �ʺ��� �ε��ϹǷ�

        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            //ù �� ������ ���� �ν��Ͻ� �ʱ�ȭ
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
