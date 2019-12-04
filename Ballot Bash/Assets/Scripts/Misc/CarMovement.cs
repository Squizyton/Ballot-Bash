using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public bool goRight, goLeft;


     public int speed;

    Rigidbody rb;

    public 
    // Start is called before the first frame update
    void Start()
    {
       rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goRight)
        {
           rb.velocity = -transform.forward * speed;
        }
        else if (goLeft)
        {
            rb.velocity = transform.forward * speed;
        }
    }

}
