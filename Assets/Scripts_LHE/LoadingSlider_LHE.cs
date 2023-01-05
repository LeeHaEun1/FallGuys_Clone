using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider_LHE : MonoBehaviour
{
    Slider slider;

    //public static Slider Instance;
    //private void Awake()
    //{
    //    Instance = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();        
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value += Time.deltaTime;
        //print(slider.value);
    }

    private void FixedUpdate()
    {
        slider.value += Time.fixedDeltaTime;
        //print(slider.value);
    }
}
