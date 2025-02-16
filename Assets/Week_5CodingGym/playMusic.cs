using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    public AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playOn()
    {
        ad.Play();
        ad.loop = true;
    }

    public void playOff()
    {
        ad.Stop();
    }
}
