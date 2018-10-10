using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletControl : MonoBehaviour {
    public float delay;
    Rigidbody2D rb;
    public Vector2 velocity; 


	void Start () {

        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, delay);
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = velocity;
	}
}
