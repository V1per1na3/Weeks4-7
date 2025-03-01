using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeSpawner : MonoBehaviour
{
    //spawner script for spikes, spawn at random countdown time
    public GameObject prefabs;
    public List<GameObject> spikes;
    float spawntimer;
    // Start is called before the first frame update
    void Start()
    {
        spikes = new List<GameObject>();
        spawntimer = Random.Range(1,3);
    }

    // Update is called once per frame
    void Update()
    {
        spawntimer -= Time.deltaTime;
        if (spawntimer <= 0)
        {
            spwanspike();//call spawn function
            spawntimer = Random.Range(0.5f,1);//reset timer

        }
        goaway();
    }

    void spwanspike()
    {
        float spawnx = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0, 0)).x;//random range between 0 to screen width
        float spawny = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height+20, 0)).y;//y= top of screen
        Vector2 pos = new Vector2(spawnx, spawny);
        GameObject newspikes = Instantiate(prefabs, pos, Quaternion.identity);//spawn spikes at set position
        spikes.Add(newspikes);//add to list
    }

    void goaway()
    {
        for (int i = spikes.Count-1; i >= 0; i--)
        {
            spikesmovement sm = spikes[i].GetComponent<spikesmovement>();
            sm.spawner = this;
            if (sm.outside)
            {
                Destroy(spikes[i]);
                spikes.Remove(spikes[i]);
            }
        }
    }

}
