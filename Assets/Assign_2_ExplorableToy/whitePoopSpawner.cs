using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class whitePoopSpawner : MonoBehaviour
{
    //this script is for spawnning white poop
    public GameObject prefab;
    public List<GameObject> whitepoop;
    public blackCarSpawner bcSpawner;//this is the black car spawner
    public Transform bird;//need a transofrm to pass the transform of bird so it can spawn at bird position
    // Start is called before the first frame update
    void Start()
    {
        whitepoop = new List<GameObject>();

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
        whitepoop.Add(newpoop);//add to list
        whitepoopMovement wm = newpoop.GetComponent<whitepoopMovement>();
        wm.spawner = this;//regreister the spawner script
        wm.bcspawner = bcSpawner;//regreister white car spawner
        wm.poop = true;
        Destroy(newpoop, 2);//destory poop after 2 sec
    }
}
