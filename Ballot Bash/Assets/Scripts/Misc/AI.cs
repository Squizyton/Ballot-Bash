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

    public bool GoRight, GoLeft;
    public int Speed;

    void Start()
    {
        GoLeft = true;
        Instantiate(leftWP, new Vector3(this.transform.position.x - DistanceOfWayPoints, this.transform.position.y, this.transform.position.z), transform.rotation);
        Instantiate(rightWP, new Vector3(this.transform.position.x + DistanceOfWayPoints, this.transform.position.y, this.transform.position.z), transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

        float distanceBetween = GameObject.FindGameObjectWithTag("Player").transform.position.x - this.transform.position.x;

        Debug.Log(distanceBetween);


        switch (state)
        {
            case State.wander:


                if (distanceBetween <= aggroRange)
                {
                    state = State.chase;
                }

                if (GoLeft)
                {
                    if (this.transform.position.x != leftWP.transform.position.x)
                    {

                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(leftWP.transform.position.x, this.transform.position.y, transform.position.z), Speed * Time.deltaTime);
                    }
                    if (this.transform.position.x == leftWP.transform.position.x)
                    {
                        GoLeft = false;
                        GoRight = true;
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


              transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, 
                  this.transform.position.y, transform.position.z), Speed * Time.deltaTime * 2);

                if (distanceBetween > 5)
                {
                    state = State.wander;
                }

                break;

        }
    }


    void MoveDude(int i)
    {
        transform.Translate(new Vector2(i, 0) * Time.deltaTime * Speed);
    }
}
