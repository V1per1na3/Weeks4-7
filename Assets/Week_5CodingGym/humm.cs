using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class humm : MonoBehaviour
{
    public SpriteRenderer sp;
    SpriteRenderer sprite;
    public Sprite[] rect;
    public bool closeEnough = false;
    playerMovement player;
    // Start is called before the first frame update
    void Start()

    {
        sprite = GetComponent<SpriteRenderer>();

        player = GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
