using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// For controlling the player movementand animations
/// </summary>

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    [Tooltip("Positive integer that multiplies the vector x movement")]
    public int speedBoost = 5;
    public float jumpSpeed = 600; //Amount og gravitational force applied
    bool isJumping;
    bool leftPressed, rightPressed;




    void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

	}
	
	void Update () {

        float playerDirection = Input.GetAxisRaw("Horizontal"); //value will return 1 for right, -1 for left or 0
        if(playerDirection != 0){
            MoveHorizontal(playerDirection);
        }else{
            StopMoving();
        }

        if(Input.GetButtonDown("Jump")){
            Jump();
        }

        if (leftPressed)
            MoveHorizontal(-speedBoost);
        if (rightPressed)
            MoveHorizontal(speedBoost);
	}

    void MoveHorizontal(float playerSpeed){

        playerSpeed *= speedBoost;
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);

        if(playerSpeed < 0){
            sr.flipX = true;
        }else if(playerSpeed > 0){
            sr.flipX = false;
        }
        if(!isJumping)
        anim.SetInteger("State", 1);
    }

    void StopMoving(){

        rb.velocity = new Vector2(0, rb.velocity.y);
        if(!isJumping)
        anim.SetInteger("State", 0);
    }

    void Jump(){
        isJumping = true;
        rb.AddForce (new Vector2(0, jumpSpeed));
        anim.SetInteger("State", 2);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Platform")){
            isJumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                SFXControllers.instance.CoinSparkle(other.gameObject.transform.position);
                break;
            default:
                break;
        }

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

    public void MobileJump(){
        Jump();
    }

    //public void MobileFireBullets(){
    //    FireBullets();
    //}
}



















