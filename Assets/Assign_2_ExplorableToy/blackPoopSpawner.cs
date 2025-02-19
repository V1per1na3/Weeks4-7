using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackPoopSpawner : MonoBehaviour
{
    //this script is for spawnning black poop
    public GameObject prefab;
    public List<GameObject> blackpoop;
    public whiteCarSpawner wcSpawner;//this is the spawner
    public Transform bird;//need a transofrm to pass the transform of bird so it can spawn at bird position
    // Start is called before the first frame update
    void Start()
    {
        blackpoop = new List<GameObject>();//a list to store spawned poop
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
        bm.spawner = this;//regreister the spawner script
        bm.wcspawner = wcSpawner;//regreister white car spawner
        bm.poop = true;
        Destroy(newpoop, 2);//destory poop after 2 sec
    }
}
