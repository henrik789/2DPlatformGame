using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoyController : MonoBehaviour {

    //public GameObject ZombieBoyPrefab;
    public float speedBoost;
    public float followSpeed;
    private int direction = 1;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Transform playerTransform;
    public bool turnAround = false;

    void Start(){

        //zombie = Instantiate(ZombieBoyPrefab).transform;
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void FixedUpdate(){

        //Patrol();
        LayerMask layerMask = ~LayerMask.GetMask("Enemy");
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTransform.position, layerMask);

        if (hit.collider.tag == "Player")
        {
            Follow();
        }else if(hit.collider.tag != "Player"){
            Patrol();
        }

    }

    void Patrol(){

        anim.SetInteger("State", 1);
        Vector3 position = transform.position;
        position.x += speedBoost * direction;
        transform.position = position;


        if (position.x > 5.2f || position.x < 1.1f)
        {
            ChangeDirection();
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            anim.SetInteger("State", 2);
            SFXControllers.instance.CoinSparkle(gameObject.transform.position);
            speedBoost = 0;

        }
    }

    void Die(){

        Destroy(gameObject);
    }

    void Follow(){

        anim.SetInteger("State", 3);
        Vector3 distance = transform.position - playerTransform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime);

        //if (distance.x > 0){
        //    turnAround = true;
        //    Debug.Log("change..!");
        //}

        //if (turnAround == true)
        //{
        //    ChangeDirection();
        //}

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
