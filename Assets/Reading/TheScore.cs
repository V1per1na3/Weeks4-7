using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject GamestartScreen;
    public TextMeshProUGUI score;
    int scoreValue = 0;
    bool isplaying = true;
    
    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreValue.ToString();
        GamestartScreen.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (isplaying ==true && Input.GetMouseButtonDown(0))
        {
            
            scoreValue++;
            score.text = scoreValue.ToString();
        }

        if (scoreValue > 10)
        {
            isplaying = false;
            GamestartScreen.SetActive(true);
        }

        if(isplaying==false && Input.GetKeyDown(KeyCode.Space))
        {
            scoreValue = 0;
            score.text = scoreValue.ToString();
            GamestartScreen.SetActive(false);
            isplaying = true;
        }
    }
}
