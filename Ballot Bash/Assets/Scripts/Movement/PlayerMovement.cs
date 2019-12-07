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
    public int WallForce;
    
    public bool FacingRight, InWall;
    public float maxVelocity = 15; //The fastest velocity the player can reach
    public float maxXVelocity;

    public AudioSource ass;


    Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {

        ass = this.GetComponent<AudioSource>();
        anim = this.GetComponent<Animator>();
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

       // Debug.Log(rb2d.velocity.y);

        //Moving the Player left and right
        MovePlayer(moveHorizontal);


        // when max velocity is reached, it cannot go higher
        if (rb2d.velocity.y >= maxVelocity)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxVelocity);
        }if(rb2d.velocity.x <= -maxXVelocity || rb2d.velocity.x >= maxXVelocity)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }


        //Jumping---------------------------
        if (rb2d.velocity.y == 0 || wallJumpAllowed)
        {
            anim.SetBool("jumping", false);
            //rb2d.velocity = new Vector2(0, 0);
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
        FlipPlayer(h);
        anim.SetBool("walking", true);
        if (h == 0)
        {
            anim.SetBool("walking", false);
        }
    
    }

    void FlipPlayer(float h)
    {

        if (h > 0)
        {
            FacingRight = true;
            this.GetComponent<SpriteRenderer>().flipX = false;
            
        }
        else if (h < 0)
        {
            FacingRight = false;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }



    }

    void DoJump()
    {
        anim.SetBool("walking", false);
        anim.SetBool("jumping", true);
        rb2d.AddForce(Vector2.up * jumpForce);

        if (InWall)
        {
            if (FacingRight)
            {     
                rb2d.AddForce(Vector2.left * WallForce);
                Debug.Log(rb2d.velocity.x);
            }
            else if (!FacingRight)
            {
                Debug.Log(rb2d.velocity.x);
                rb2d.AddForce(Vector2.right * WallForce);
            }
        }
        ass.Play();
    }


    //Collisions
    void OnCollisionEnter2D(Collision2D col)
    {
        {
            if (col.gameObject.tag.Equals("Wall"))
            {
                InWall = true;
                MovePlayer(0);
                wallJumpAllowed = true;
            }

        }

    
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
        {
            InWall = false;
            wallJumpAllowed = false;
        }

    }

    //Triggers
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Voter"))
        {
            Debug.Log("Sentencing");
            col.gameObject.GetComponent<Conversation>().DisplayNPCSentence();
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Voter"))
        {
              col.gameObject.GetComponent<Conversation>().PlayerLeft();
        }
    }
}
