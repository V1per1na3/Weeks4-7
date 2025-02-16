using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbullet : MonoBehaviour
{
    public GameObject prefabs;
    public List<GameObject> bullets;
    AudioSource audio;
    public AudioClip clip;
    public Transform aimpivot;//need a transform to pass the transform of barrel top so bullet shoot from top of barrel
    // Start is called before the first frame update
    void Start()
    {
        //a list to store spawned bullet
        bullets = new List<GameObject>();
        //get audiosource component
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if player hits mouse left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            soundeffect();
            //spawn the bullet
            //this is the current position of barrel top
            //bullet will spawn at this position
            Vector3 pos = aimpivot.position;
            pos.z = 0;//don need z
            GameObject newbull = Instantiate(prefabs,pos, Quaternion.identity);//spawn at barrel top, no rotation.
            //add it to list
            bullets.Add(newbull);
            //regrstration
            bulletscript bs = newbull.GetComponent<bulletscript>();
            bs.spawner = this;
            //tell bullet to shoot
            bs.fired = true;
            //destroy after 2s
            Destroy(newbull, 2);
            
        }
    }

    void soundeffect()
    {
        //play when theres no sound effect so it's only play once
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(clip);
        }
    }
}
