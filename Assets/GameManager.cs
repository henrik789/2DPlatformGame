using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private Text scoreText;
    public int score = 0;
    public int lives = 3;
    public float distance = 0.5f;
    string sceneName;
    bool gameover = false;
    public float restartDelay;



    private static GameManager _instance;

    public static GameManager Instance { get {

            if (_instance == null) {

                //instanciate new GameManager
            }

            return _instance;
        }}

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start () {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(" "+ sceneName);

    }
	

	void Update () {
        //if(gameover){
        //    SceneManager.
        //}
	}


    void ReloadLevel()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LooseOneLife(){
        lives -= 1;
        if (lives == 0)
        {
            gameover = true;
            SceneManager.LoadScene("Menu");
        }
        else
        {
            ReloadLevel();
            Debug.Log("lives: " + lives);
            //Invoke("ReloadLevel", restartDelay);
        }
    }


    public void ScoreUpdate(){
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void LevelCompleted(){
        SceneManager.LoadScene("LevelTwo"); // Level 2 should start here.
    }


}
