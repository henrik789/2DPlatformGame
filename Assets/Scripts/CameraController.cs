using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    //float yOffset = 2.2f;

	void Start () {
		
	}
	

	void Update () {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z); 
	}
}
