using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LIfeController : MonoBehaviour {

    public Sprite emptyHeart;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    // Use this for initialization
    void Start () {
        InitHearts();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitHearts(){
        int lives = GameManager.Instance.lives;
        if (lives == 2)
        {
            heart1.GetComponent<Image>().sprite = emptyHeart;
        }
        else if(lives == 1){
            heart1.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = emptyHeart;
        }
        else if(lives == 0){
            heart1.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = emptyHeart;
            heart3.GetComponent<Image>().sprite = emptyHeart;
        }
    }

}
