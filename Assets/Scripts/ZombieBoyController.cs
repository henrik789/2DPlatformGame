using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoyController : MonoBehaviour {

    public GameObject zombieBoy;
    public float speedBoost;
    private int direction = 1;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Transform playerTransform;



    void Start(){

        anim = GetComponent<Animator>();
        anim.SetInteger("State", 1);
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }






    void Update(){


        Patrol();

        LayerMask layerMask = ~LayerMask.GetMask("Enemy");

        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTransform.position, layerMask);

        if (hit.collider.tag == "Player")
        {
            Follow();
            Debug.Log("Player hit");
        }
        else
        {
            anim.SetInteger("State", 1);
        }

    }

    void Patrol(){

        Vector3 position = transform.position;
        position.x += speedBoost * direction;
        transform.position = position;

        if (position.x > 6.0f || position.x < 1.3f)
        {
            ChangeDirection();
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetInteger("State", 2);
            speedBoost = 0;
            //Destroy(gameObject);


        }
    }


    void Follow(){

        anim.SetInteger("State", 3);
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speedBoost * Time.deltaTime);

        //anim.SetFloat(distanceHash, Vector2.Distance(anim.transform.position, playerTransform.position));

    }



    void ChangeDirection()
    {

        direction *= -1;

        if (direction == -1)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction == 1)
        {
            spriteRenderer.flipX = false;
        }
    }

}
