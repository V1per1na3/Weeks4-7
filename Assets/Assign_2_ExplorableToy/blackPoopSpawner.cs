using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackPoopSpawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> blackpoop;
    public whiteCarSpawner wcSpawner;
    public Transform bird;//need a transofrm to pass the transform of bird so it can spawn at bird position
    // Start is called before the first frame update
    void Start()
    {
        blackpoop = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnthepoop()
    {
        Vector3 pos = bird.position;//spawn at bird position
        pos.z = 0;
        GameObject newpoop = Instantiate(prefab, pos, Quaternion.identity);//spawn
        blackpoop.Add(newpoop);//add to list
        blackpoopMovement bm = newpoop.GetComponent<blackpoopMovement>();
        bm.spawner = this;//regreister 
        bm.wcspawner = wcSpawner;//regreister
        bm.poop = true;
        Destroy(newpoop, 2);//destory poop after 2 sec
    }
}
