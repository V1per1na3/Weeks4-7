using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //this script is for score stuff
    //link to score ui
    //if black poop hits white car, score+1
    //if white poop hits black car, score+1
    public blackpoopMovement mb;
    public TextMeshProUGUI score;
    float scorevalue = 0f;
    float point = 1;
    // Start is called before the first frame update
    void Start()
    {
        score.text = scorevalue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        addscore();
        mb.hitcar = false;//reset hitcar condition
    }

    public void addscore()
    {
        //add score if car hit by poop
        
        if (mb.hitcar)//if black poop hits white car
        {
            
            //Debug.Log("hitcaristrue");
            scorevalue += point;//add score
            score.text = scorevalue.ToString();//update score
            
        }

    }
}
