using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGirlController : MonoBehaviour
{

    public float speedBoost;
    private int direction = 1;
    SpriteRenderer spriteRenderer;
    Animator anim;



    void Start()
    {

        anim = GetComponent<Animator>();
        //anim.SetInteger("State", 1);
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Update()
    {


        Vector3 position = transform.position;
        position.x += speedBoost * direction;
        transform.position = position;

        if (position.x > 62.1f || position.x < 53.7f)
        {
            ChangeDirection();
        }

    }



    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        anim.SetInteger("State", 2);
    //        speedBoost = 0;


    //    }
    //}



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
