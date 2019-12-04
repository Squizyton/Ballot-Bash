using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpDown : MonoBehaviour
{
    // Start is called before the first frame update

    public bool goUp, goDown;

    [Tooltip("These variables can be edited to tell the platform how far to go up")]
   public float goUpThisMuch;

    [Tooltip("These are Debug logs!")]
    public float debugUp, debugDown;

    public Vector3 Orginal_Position;

    void Start()
    {
        debugUp = this.transform.position.y + goUpThisMuch;
        Orginal_Position = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
      if(goUp)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime);

            if (this.transform.position.y == this.transform.position.y + goUpThisMuch)
            {
                goUp = false;
                goDown = true;
            }
        }


        if (goDown)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime);

            if (this.transform.position == Orginal_Position)
            {
                goUp = true;
                goDown = false;
            }

        }


    }
}
