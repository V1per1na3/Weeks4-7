using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cuckooClock : MonoBehaviour
{
    public SpriteRenderer BD;
    public float hourspeed =5f;
    public AudioSource chime;
    public AudioClip clip;
    public int enableCount;
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        BD.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z -= hourspeed*Time.deltaTime;
        transform.eulerAngles = rot;
        int wholeN = (int) rot.z;
        //Debug.Log();
        if(Mathf.Abs(wholeN % 30)==0)
        {
            if (chime.isPlaying == false)
            {
                chime.PlayOneShot(clip);
                BD.enabled = true;
            }

        }
        else
        {
            BD.enabled = false;
        }
        
    }
}
