using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGirlController : MonoBehaviour
{

    public float speedBoost;
    private int direction = 1;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float followSpeed;
    Transform playerTransform;
    public bool turnAround = false, zombieGirlAlive = true;


    void Start()
    {

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {

        LayerMask layerMask = ~LayerMask.GetMask("Enemy");
        if (playerTransform != null)
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTransform.position, layerMask);

            if (hit.collider.tag == "Player")
            {
                Follow();
            }
            else if (hit.collider.tag != "Player")
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        if (zombieGirlAlive)
        {
            anim.SetInteger("State", 0);
        }

        Vector3 position = transform.position;
        position.x += speedBoost * direction;
        transform.position = position;


        if (position.x > 100f || position.x < 95.5f)
        {
            ChangeDirection();
        }

    }


    public void ZombieGirlDie()
    {
        Debug.Log("Shot!");
        zombieGirlAlive = false;
        {
            speedBoost = 0;
            anim.SetInteger("State", 2);
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }

    void Follow()
    {
        if (zombieGirlAlive)
        {
            anim.SetInteger("State", 3);
        }

        Vector3 distance = transform.position - playerTransform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime);

        if (distance.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
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
