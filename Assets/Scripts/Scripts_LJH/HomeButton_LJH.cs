using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton_LJH : MonoBehaviour
{
    public void OnClickHomeButton()
    {
        Record_LJH.instance.recordSecs.Clear();
        SceneManager.LoadScene("Map1");
    }
}
