using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BusCutscene : MonoBehaviour
{

    public GameObject Bus, TheBus;
    public GameObject black;
    // Start is called before the first frame update
    void Start()
    {
        black = GameObject.Find("black");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
            {
            col.gameObject.GetComponent<PlayerMovement>().speed = 0;
            col.gameObject.GetComponent<PlayerMovement>().jumpForce = 0;
           TheBus = Instantiate(Bus, new Vector3(301.37f, 7.07f, -5.02f), Quaternion.Euler(0, 270, -180));
        }

        StartCoroutine(BusSecondAnimation());

    }

    IEnumerator BusSecondAnimation()
    {
        yield return new WaitForSeconds(6f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
        TheBus.GetComponent<Animator>().SetBool("ToCity", true);
        yield return new WaitForSeconds(1f);
        black.GetComponent<Animator>().SetBool("Fade", true);

    }



}
