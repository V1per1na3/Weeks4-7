using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateSpawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> spawnedprefabs;
    public int niceclick;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnedprefabs = new List<GameObject>();
        SpawnIt();
        niceclick = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnIt()
    {
        for (int i=0; i < 5; i++)
        {
            Vector2 pos = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));//set random pos
            Vector2 screenpos = Camera.main.ScreenToWorldPoint(pos);//make sure its inside the screen
            GameObject newPirate = Instantiate(prefab, screenpos, Quaternion.identity);//spawn the prefab
            spawnedprefabs.Add(newPirate);//add to the list
            piratestuff myscript = newPirate.GetComponent<piratestuff>();
            myscript.thingthatspawnMe = this;
        }
        
    }

    public void Gameover()
    {
        for (int i=0; i < spawnedprefabs.Count; i++)
        {
            Destroy(spawnedprefabs[i]);
        }//destroy all prefabs from the list
        SpawnIt();//spawn the prefabs again
        niceclick = 0;//reset success click
    }
}
