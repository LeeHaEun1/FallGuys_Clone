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
            //ù �� ������ ���� �ν��Ͻ� �ʱ�ȭ
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
