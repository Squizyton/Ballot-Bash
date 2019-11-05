using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.
    public bool jumpAllowed = false; // Can the player jump?
    bool wallJumpAllowed = false; //Can the player Wall Jump?


    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public int jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");



        //Moving the Player left and right
        MovePlayer(moveHorizontal);


        //Jumping---------------------------
        if (rb2d.velocity.y == 0 || wallJumpAllowed)
        {
            jumpAllowed = true;
        }
        else
        {
            jumpAllowed = false;
        }
        if (Input.GetButtonDown("Jump") && jumpAllowed)
        {
            DoJump();
        }

    }

    void MovePlayer(float h)
    {
         transform.Translate(new Vector2 (h,0) * Time.deltaTime * speed);
       // rb2d.AddForce(Vector2.left * h);
    
    }

    void DoJump()
    {
        rb2d.AddForce(Vector2.up * jumpForce);
    }


    //Collisions
    void OnCollisionEnter2D(Collision2D col)
    {
        {
            if (col.gameObject.tag.Equals("Wall"))
            {

                MovePlayer(0);
                wallJumpAllowed = true;
            }
        }
    
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
        {
            wallJumpAllowed = false;
        }

    }



}
