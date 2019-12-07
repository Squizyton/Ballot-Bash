using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Conversation : MonoBehaviour
{
    // Start is called before the first frame update

    [TextArea(3, 2)]
    public string[] NPC_sentences;

    [TextArea(3, 2)]
    public string PlayerSentences;

    public GameObject SpawnNPCTextBox;
    public GameObject NPCTextBox;
    public GameObject playerTextbox;

    public bool BlueNPC, RedNPC;

    public int sentenceNumber;

    public Sprite blueHead, greenHead;

    //THIS WILL MANUALLY HAVE TO BE SET
    public bool onGround, gotBallot;

    private void Start()
    {
        NPCTextBox = Instantiate(SpawnNPCTextBox, GameObject.FindGameObjectWithTag("Canvas").transform, false);
        NPCTextBox.name = this.gameObject.name + "'s dialouge box";

      ///  playerTextbox = GameObject.Find("PlayerTextBox");

        if (BlueNPC)
        {
            NPCTextBox.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().sprite = blueHead;
        }

        if (RedNPC)
        {
            //Replace Image with Blue Head

        }
        NPCTextBox.SetActive(false);
        playerTextbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       public void DisplayNPCSentence()
    {
        if (NPCTextBox.activeSelf != true)
        {
            NPCTextBox.SetActive(true);
        }

        NPCTextBox.transform.GetChild(0).GetComponent<Text>().text = NPC_sentences[sentenceNumber]; 
    }




   public void DisplayPlayerSentence()
    {
        if (NPCTextBox.activeSelf.Equals(true))
        {
            NPCTextBox.SetActive(false);
        }
        playerTextbox.SetActive(true);

       playerTextbox.transform.GetChild(1).GetComponent<Text>().text = PlayerSentences;
    }

    public void PlayerLeft()
    {
        if (gotBallot)
        {
            if (onGround)
            {
                this.gameObject.transform.position += Vector3.right * 5 * Time.deltaTime;
            }
            else
            {
                this.gameObject.GetComponent<DestroyNPC>().DestroyGameObject();
            }
        }

        NPCTextBox.SetActive(false);
        playerTextbox.SetActive(false);
    }

}
