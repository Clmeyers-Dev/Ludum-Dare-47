using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed;
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;
    public Rigidbody2D rb;
    public Animator animator;
    public int rangedDamage = 1;
    //Dash 
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    float ButtonCooler = 0.3f; // Half a second before reset
    int ButtonCount = 0;
    public int direction;
    bool dashUp;
    bool dashLeft;
    bool dashRight;
    bool dashDown;
    //bools that unlock Player ablities 
    public bool canRanged;
    public bool hasSword;
    public bool canDash;
    private float thrust = 10.0f;

    Vector2 movement;
    public void Start()
    {
        hasSword = true;
    }
    // Update is called once per frame
    void Update ()
    {
        handleMovement();
       
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
               
                dashUp = true;
            }
            else
            {
                ButtonCooler = 0.3f;
                ButtonCount += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
                dashLeft = true;
            }
            else
            {
                ButtonCooler = 0.3f;
                ButtonCount += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
                dashRight = true;
            }
            else
            {
                ButtonCooler = 0.3f;
                ButtonCount += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
                dashDown = true;
            }
            else
            {
                ButtonCooler = 0.3f;
                ButtonCount += 1;
            }
        }
        if (ButtonCooler > 0)
        {

            ButtonCooler -= 1 * Time.deltaTime;

        }
        else
        {
            ButtonCount = 0;
        }
        handleAblities();
    }
    public void handleAblities()
    {
        if (isAttacking)
        {
            moveSpeed = 0f;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }

        if (canRanged)
        {
            if (hasSword)
            {
                //useSword
                hasSword = false;
            }
          
        }
        if (canDash)
        {
            if (direction == 0)
            {
                if (dashLeft)
                {
                    //Instantiate(dashEffect, transform.position, Quaternion.identity);
                    //trail.SetActive(true);
                    direction = 1;
                    //PlayerAnimator.SetBool("isDashing", true);


                    dashLeft = false;

                }
                else if (dashRight)
                {
                    //Instantiate(dashEffect, transform.position, Quaternion.identity);

                    direction = 2;
                    //PlayerAnimator.SetBool("isDashing", true);

                    dashRight = false;

                }
                else if (dashUp)
                {
                    //Instantiate(dashEffect, transform.position, Quaternion.identity);

                    direction = 3;
                    //PlayerAnimator.SetBool("isDashing", true);

                    dashUp = false;

                }
                else if (dashDown)
                {
                    //Instantiate(dashEffect, transform.position, Quaternion.identity);
                    
                    direction = 4;
                    dashDown = false;
                    //PlayerAnimator.SetBool("isDashing", true);
                   
                  
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;

                    //PlayerAnimator.SetBool("isDashing", false);

                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        Debug.Log("Dash left");
                        rb.velocity = Vector2.left * dashSpeed;

                    }
                    else if (direction == 2)
                    {
                        Debug.Log("Dash right");
                        rb.velocity = Vector2.right * dashSpeed;
                    }
                    else if (direction == 3)
                    {
                        Debug.Log("Dash Up");
                        rb.velocity = Vector2.up * dashSpeed;
                    }
                    else if (direction == 4)
                    {
                        Debug.Log("Dash down");
                        rb.velocity = Vector2.down * dashSpeed;
                    }
                }
            }
        }
    }
    public void handleMovement()
    {
       
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
    public void setHasSword(bool has)
    {
        hasSword = has;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            hasSword = true;
            Destroy(other.gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement*moveSpeed*Time.fixedDeltaTime);
       
    }
    public void dash()
    {
    }
}



