using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{ 
    private float Velocity;
    private new Rigidbody2D rigidbody2D;
    private bool IsOnRight = true;
    private float Jumb = 450;
    //amimation
    private float Speed;
    private bool IsOnGround = true;
    private bool IsDie = false;
    private bool IsAttack = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Velocity = 3;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Speed);
        animator.SetBool("IsOnGround", IsOnGround);
        animator.SetBool("IsDie", IsDie);
        animator.SetBool("IsAttack", IsAttack);

        //nhay , neu dang duoi dat
        if (
            (
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W) ||
            (Input.GetKeyDown(KeyCode.Space))
            ) &&
            IsOnGround == true
        )
        {
            rigidbody2D.AddForce(Vector2.up * Jumb);

            // PlaySound("smb_jump");
            IsOnGround = false;
            Debug.Log (IsOnGround);
        }

        //attack
        if (Input.GetKey(KeyCode.C))
        {
            IsAttack = true;  
        }else{
            IsAttack = false;  
        }
    }

    private void FixedUpdate()
    {
        //phim bam mui ten trai phai
        float direction = Input.GetAxis("Horizontal");
        rigidbody2D.velocity =
            new Vector2(direction * Velocity, rigidbody2D.velocity.y);
        Speed = Mathf.Abs(direction * Velocity);
        if (
            (direction > 0 && IsOnRight == false) ||
            (direction < 0 && IsOnRight == true)
        )
        {
            IsOnRight = !IsOnRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            IsOnGround = true;
        }

        if (collision.gameObject.tag == "Mouse")
        {
            if(IsAttack==true){
                Destroy(collision.gameObject);
            }else{
                IsDie = true;
            }  
        }


        // if (collision.gameObject.tag == "Coin")
        // {
        //     PlaySound("smb_coin");
        //     Destroy(collision.gameObject);
        // }

        // if (collision.gameObject.tag == "Enemy" && IsOnGround==false)
        // {
        //     Destroy(collision.gameObject);
        // }

        // if (collision.gameObject.tag == "Enemy" && IsOnGround == true)
        // {
        //     PlaySound("smb_gameover");
        //     Destroy(gameObject);
        // }
    }

    
}
