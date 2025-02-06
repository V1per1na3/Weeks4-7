using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Slider sliders;// or make it public
    float t;
    // Start is called before the first frame update
    void Start()
    {
        sliders = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        sliders.value = t% sliders.maxValue;
    }
}
