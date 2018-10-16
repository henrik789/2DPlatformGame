using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {

    public CoinFX coinFX;
    public GameManager gameManager;

    public enum CoinFX{
        Vanish, fly
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (coinFX == CoinFX.Vanish)
              {
                    gameManager.ScoreUpdate();
                    Destroy(gameObject);
              }
    }

    //public void ScoreCount()
    //{
    //    score += 10;
    //    scoreText.text = "Score: " + score;
    //    Debug.Log("Score: " + score);
    //}

}
