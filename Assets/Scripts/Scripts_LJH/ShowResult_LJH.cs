using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowResult_LJH : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    // Start is called before the first frame update
    void Start()
    {
        if (Record_LJH.instance.recordSecs.Count > 0)
        {
            for (int i = 0; i < Record_LJH.instance.recordSecs.Count; i++)
            {
                resultText.text += (int)Record_LJH.instance.recordSecs[i] / 60 + " 분 " + Mathf.Round(Record_LJH.instance.recordSecs[i] % 60) + " 초";
                resultText.text += "\n\n";
            }
        }
        else
        {
            resultText.text = "결과 없음!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
