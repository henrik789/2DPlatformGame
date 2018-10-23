using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletControl : MonoBehaviour {
    public float delay;
    Rigidbody2D rb;
    public Vector2 velocity;
    //public ZombieBoyController zombieBoyController;

	void Start () {

        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, delay);
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = velocity;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Enemy")){
            //Debug.Log("Shot!");
            other.gameObject.GetComponent<ZombieBoyController>().ZombieBoyDie(); 


        }if(other.gameObject.CompareTag("ZombieGirl")){

            other.gameObject.GetComponent<ZombieGirlController>().ZombieGirlDie();
        }
        if(other.gameObject.CompareTag("Platform")){
            Destroy(gameObject);
        }
    }

}
