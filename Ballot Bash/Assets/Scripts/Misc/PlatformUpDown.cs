using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpDown : MonoBehaviour
{
    // Start is called before the first frame update

    public bool goUp, goDown;


    public int speed;


    [Tooltip("These variables can be edited to tell the platform how far to go up")]
   public float goUpThisMuch;

    [Tooltip("These are Debug logs!")]
    public float debugUp, debugDown;

    public Vector2 Orginal_Position;

    void Start()
    {
        debugUp = this.transform.localPosition.y + goUpThisMuch;
        Orginal_Position = this.transform.localPosition;
        speed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(goUp)
        {
            this.transform.Translate(Vector2.up * Time.deltaTime * speed);

            if (this.transform.localPosition.y >= debugUp)
            {
                goUp = false;
                goDown = true;
            }
        }


        if (goDown)
        {
            this.transform.Translate(Vector2.down * Time.deltaTime * speed);

            if (this.transform.localPosition.y <= Orginal_Position.y)
            {
                goUp = true;
                goDown = false;
            }

        }


    }
}
