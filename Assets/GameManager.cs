using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text scoreText;
    public int score = 0;


    void Start () {
		
	}
	

	void Update () {
		
	}

    public void ScoreUpdate(){
        score += 10;
        scoreText.text = "Score: " + score;
        //Debug.Log("Score: " + score);
    }

}
