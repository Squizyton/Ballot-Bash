using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update

    //State of the AI;
    public enum State { wander, chase }
    public State state;

    public GameObject SpawnleftWP, SpawnrightWP;
    public int DistanceOfWayPoints;
    public GameObject LeftWP, RightWP;

    public int aggroRange;

    public Rigidbody2D rb;

    public bool GoRight, GoLeft;
    public int Speed;

    public SpriteRenderer sr;

    public int DeAggro;

    bool facingRight;

    void Start()
    {
        GoLeft = true;
        LeftWP = Instantiate(SpawnleftWP, new Vector3(this.transform.position.x - DistanceOfWayPoints, this.transform.position.y, this.transform.position.z), transform.rotation);
       RightWP = Instantiate(SpawnrightWP, new Vector3(this.transform.position.x + DistanceOfWayPoints, this.transform.position.y, this.transform.position.z), transform.rotation);
        rb = this.GetComponent<Rigidbody2D>();
        Debug.Log("Right Waypoint : " + RightWP.transform.position + "Left Waypoint: " + LeftWP.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       
        float distanceBetween = GameObject.FindGameObjectWithTag("Player").transform.position.x - this.transform.position.x;
        distanceBetween = Mathf.Abs(distanceBetween);

        //Debug.Log(distanceBetween);
        float HeightDistance = GameObject.FindGameObjectWithTag("Player").transform.position.y - this.transform.position.y;
        //Debug.Log(distanceBetween);


        switch (state)
        {
            case State.wander:


                if (distanceBetween <= aggroRange && HeightDistance <= aggroRange)
                {
                    state = State.chase;
                }

                if (GoLeft)
                {
                    sr.flipX = true;

                    
                    if (transform.position.x != LeftWP.transform.position.x)

                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(LeftWP.transform.position.x, this.transform.position.y, transform.position.z), Speed * Time.deltaTime);
 
                    }
                    if (transform.position.x == LeftWP.transform.position.x)
                    {
                        Debug.Log("Connected");
                        GoLeft = false;
                        GoRight = true;
                      
                    }
                    
                }


                if (GoRight)
                {
                    sr.flipX = false;

                    if (this.transform.position.x != RightWP.transform.position.x)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(RightWP.transform.position.x, this.transform.position.y, transform.position.z), Speed * Time.deltaTime);
                        
                    }
                    if (this.transform.position.x == RightWP.transform.position.x)
                    {
                        GoLeft = true;
                        GoRight = false;

                    }
                }




                break;


            case State.chase:

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, this.transform.position.y, transform.position.z), Speed * Time.deltaTime);

                if (GameObject.FindGameObjectWithTag("Player").transform.position.x > this.transform.position.x)
                {
                    sr.flipX = false;
                }
                else
                {
                    sr.flipX = true;
                }


                if (distanceBetween > DeAggro || HeightDistance > DeAggro)
                {
                   state = State.wander;
                }
                break;
        }
     //   Debug.Log(transform.right);
    }

}
