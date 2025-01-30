using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableDisable : MonoBehaviour
{
    public GameObject menu;
    public AudioSource clickSound;
    //public SpriteRenderer sr;
    public enableDisable script;
    public AudioClip clip;
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sr.enabled = false;
            menu.SetActive(false);
            //script.enabled = false;


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sr.enabled = true;
            menu.SetActive(true);
            //script.enabled = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (clickSound.isPlaying == false)
            {
                //clickSound.Play();
                clickSound.PlayOneShot(clip);
            }

        }
        
    }
}
