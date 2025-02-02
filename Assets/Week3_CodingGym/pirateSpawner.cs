using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateSpawner : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnIt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnIt()
    {
        for (int i=0; i < 5; i++)
        {
            Vector2 pos = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
            Vector2 screenpos = Camera.main.ScreenToWorldPoint(pos);
            GameObject newPirate = Instantiate(prefab, screenpos, Quaternion.identity);//quaternion.identity = no rotation
        }
    }
}
