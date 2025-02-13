using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class bulletscript : MonoBehaviour
{
    public float speed = 5f;
    public bool fired = false;
    public spawnbullet spawner;
    bool isplaying;

    // Start is called before the first frame update
    void Start()
    {
        pointtomouse();
    }

    // Update is called once per frame
    void Update()
    {
        //now bullet need to move towards the mouse if player fire
        if (fired)
        {
            shoot();
        }

    }

    void pointtomouse()
    {
        Vector3 pos = transform.position;
        pos.z = 0;//don need z
        //get mouse position
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;//don need z
        //bullet point to mouse
        transform.right = mouse - pos;
    }

    void shoot()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;
    }

}
