using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject black;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine(timer());
        }
    }

    IEnumerator timer()
    {
        black.GetComponent<Animator>().SetBool("Fade", true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TutorialScene");
    }

}
