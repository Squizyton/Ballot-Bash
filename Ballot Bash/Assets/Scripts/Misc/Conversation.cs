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
    public string[] PlayerSentences;

    public GameObject SpawnNPCTextBox;
    public GameObject NPCTextBox;
    public GameObject playerTextbox;

    public bool BlueNPC, RedNPC;

    public int sentenceNumber;

    private void Start()
    {
        NPCTextBox = Instantiate(SpawnNPCTextBox, GameObject.FindGameObjectWithTag("Canvas").transform,false);
        NPCTextBox.name = this.gameObject.name + "'s dialouge box";
        


        if (BlueNPC)
        {
            NPCTextBox.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
        }

        if (RedNPC)
        {
            //Replace Image with Blue Head

        }
        NPCTextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       public void DisplayNPCSentence()
    {
       
      // if (playerTextbox.activeSelf.Equals(true))
      // {
      //     playerTextbox.SetActive(false);
      // }

        if (NPCTextBox.activeSelf != true)
        {
            NPCTextBox.SetActive(true);
        }

        NPCTextBox.transform.GetChild(0).GetComponent<Text>().text = NPC_sentences[sentenceNumber]; 
    }




    void DisplayPlayerSentence()
    {

    }

    public void PlayerLeft()
    {
        NPCTextBox.SetActive(false);
        playerTextbox.SetActive(false);
    }

}
