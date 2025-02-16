using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playMusic : MonoBehaviour
{
    public AudioSource ad;
    public Slider sliders;
    public bool isplaying = false;
    float t;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isplaying)//if playing start timer slider
        {
            t += Time.deltaTime;
            sliders.maxValue = ad.clip.length;//max value is the audio clip length
            sliders.value = t % sliders.maxValue;
        }
        if (!isplaying)
        {
            sliders.value = 0;//reset sldier to 0 if its not playing anymore
        }
    }

    public void playOn()
    {
        if (!isplaying)
        {
            ad.Play();
            //ad.loop = true;
            isplaying = true;
        }
    }

    public void playOff()
    {
        ad.Stop();
        isplaying = false;
    }

}
