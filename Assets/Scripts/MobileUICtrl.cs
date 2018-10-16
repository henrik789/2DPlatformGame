using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour {

    public GameObject player;
    PlayerController playerController;

	void Start () {

        playerController = player.GetComponent<PlayerController>();
 	
    }

    public void MobileMoveLeft(){
        playerController.MobileMoveLeft();
    }

    public void MobileMoveRight(){
        playerController.MobileMoveRight();
    }

    public void MobileStop(){
        playerController.MobileStop();
    }
    public void MobileJump(){
        playerController.MobileJump();
    }

    public void MobileFireBullets(){
        playerController.MobileFireBullets();
    }
}
