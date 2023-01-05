using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager_LJH : MonoBehaviour
{
    public GameObject exitCheckPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickExitButton()
    {
        exitCheckPanel.SetActive(true);
    }
    public void OnClickCancelButton()
    {
        exitCheckPanel.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
