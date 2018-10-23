using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour {

    Transform platformTransform;
    public float speedBoost;
    private int direction = 1;
    //public float upForce;
    void Start () {
		
	}
	

	void Update () {

        Vector3 position = transform.position;
        position.x += speedBoost * direction;
        //position.y *= upForce;
        transform.position = position;


        if (position.x > 122f || position.x < 118f)
        {
            direction *= -1;
        }
    }


}
