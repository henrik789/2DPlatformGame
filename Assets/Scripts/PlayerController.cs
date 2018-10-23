using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// For controlling the player movementand animations
/// </summary>

public class PlayerController : MonoBehaviour
{
    public LIfeController lIfeController;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    //public GameManager gameManager;
    [Tooltip("Positive integer that multiplies the vector x movement")]
    public int speedBoost;
    public float jumpSpeed; //Amount of uplift applied
    bool isJumping;
    public bool isGrounded, levelDone = false;
    public float delayForDoubleJump = 0.2f;
    bool leftPressed, rightPressed;
    public Transform leftBulletSpawnPosition, rightBulletSpawnPosition;
    public GameObject leftBullet, rightBullet;
    bool playerAlive = true, canFireBullets = false;
    public int numberOfJumps = 0;
    private int maxJumps = 2;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {


            //isGrounded = Physics2D.OverlapBox
            float playerDirection = Input.GetAxisRaw("Horizontal"); //value will return 1 for right, -1 for left or 0
            if (playerDirection != 0)
            {
                MoveHorizontal(playerDirection);
            }
            else
            {
                StopMoving();
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (leftPressed)
                MoveHorizontal(-speedBoost);
            if (rightPressed)
                MoveHorizontal(speedBoost);

            if (Input.GetButtonDown("Fire1") && canFireBullets)
            {
                FireBullets();
            }
            if(levelDone){
            GameManager.Instance.LevelCompleted();   
            }

    }

    void MoveHorizontal(float playerSpeed)
    {

        playerSpeed *= speedBoost;
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);

        if (playerSpeed < 0)
        {
            sr.flipX = true;
        }
        else if (playerSpeed > 0)
        {
            sr.flipX = false;
        }
        if (!isJumping && playerAlive)
            anim.SetInteger("State", 1);
            
    }

    void StopMoving()
    {

        rb.velocity = new Vector2(0, rb.velocity.y);
        if (!isJumping && playerAlive)
               anim.SetInteger("State", 0);
            
    }

    void Jump()
    {
        isJumping = true;
        if(isGrounded){
            numberOfJumps = 0;
        }
        rb.AddForce(new Vector2(0, jumpSpeed));
        if(playerAlive)
        anim.SetInteger("State", 2);
        if (isGrounded || numberOfJumps < maxJumps)
        {

            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpSpeed));
            numberOfJumps += 1;
            isGrounded = false;

        }

    }

    void FireBullets()
    {

        if (sr.flipX)
            Instantiate(leftBullet, leftBulletSpawnPosition.position, Quaternion.identity);
        if (!sr.flipX)
            Instantiate(rightBullet, rightBulletSpawnPosition.position, Quaternion.identity);


    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform")){
            isJumping = false;
            isGrounded = true;
        }
        else if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("ZombieGirl"))
        {
            GameManager.Instance.LooseOneLife();
            playerAlive = false;
            anim.SetInteger("State", 4);
            Debug.Log("killed");

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                SFXControllers.instance.CoinSparkle(other.gameObject.transform.position);
                //Debug.Log("sparkle");
                break;
            case "Enemy":
                playerAlive = false;
                anim.SetInteger("State", 4);
                Debug.Log("killed");
                break;
            case "Platform":
                SFXControllers.instance.PlayerLands(other.gameObject.transform.position);
                break;
            case "RedKey":
                canFireBullets = true;
                break;
            case "YellowKey":
                levelDone = true;
                break;
            default:
                break;
        }

    }

    void PlayerDead(){

        Destroy(gameObject);

    }

    public void MobileMoveLeft()
    {
        leftPressed = true;
    }

    public void MobileMoveRight()
    {
        rightPressed = true;
    }

    public void MobileStop()
    {
        leftPressed = false;
        rightPressed = false;
        StopMoving();
    }

    public void MobileJump()
    {
        Jump();
    }

    public void MobileFireBullets(){
        FireBullets();
    }
}

