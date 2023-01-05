using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record_LJH : MonoBehaviour
{
    public static Record_LJH instance = null;

    public List<float> recordSecs;

    private void Awake()
    {
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
