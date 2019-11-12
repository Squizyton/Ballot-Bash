using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update

    //State of the AI;
    public enum State { wander, chase }
    public State state;

    public GameObject leftWP, rightWP;
    public int DistanceOfWayPoints;
    public int aggroRange;

    public Rigidbody2D rb;

    public bool GoRight, GoLeft;
    public int Speed;


    bool facingRight;

    void Start()
    {
        GoLeft = true;
        Instantiate(leftWP, new Vector3(this.transform.position.x - DistanceOfWayPoints, this.transform.position.y, this.transform.position.z), transform.rotation);
        Instantiate(rightWP, new Vector3(this.transform.position.x + DistanceOfWayPoints, this.transform.position.y, this.transform.position.z), transform.rotation);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        float distanceBetween = GameObject.FindGameObjectWithTag("Player").transform.position.x - this.transform.position.x;

        //Debug.Log(distanceBetween);
       

        switch (state)
        {
            case State.wander:


                if (distanceBetween <= aggroRange)
                {
                    state = State.chase;
                }

                if (GoLeft)
                {

                    if (rb.position.x != leftWP.transform.position.x)
                    {
                        rb.MovePosition(transform.position + -transform.right * Time.deltaTime);
                        
                    }
                    if (rb.position.x == leftWP.transform.position.x)
                    {
                        Debug.Log("Connected");
                        GoLeft = false;
                        GoRight = true;
                        Vector3 localScale = transform.localScale;
                        localScale.x *= -1;
                    }
                    
                }


                if (GoRight)
                {
                        

                    if (this.transform.position.x != rightWP.transform.position.x)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(rightWP.transform.position.x, this.transform.position.y, transform.position.z), Speed * Time.deltaTime);
                        
                    }
                    if (this.transform.position.x == rightWP.transform.position.x)
                    {
                        GoLeft = true;
                        GoRight = false;
                    }
                }




                break;


            case State.chase:



             
                if (distanceBetween > 5)
                {
                    state = State.wander;
                }

                break;


         

        }


     //   Debug.Log(transform.right);
    }

}
